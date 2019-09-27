using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Polly;
using System.Threading.Tasks;
using System.Net;
using Refit;
using Plugin.Connectivity.Abstractions;
using Acr.UserDialogs;
using Plugin.Connectivity;
using System.Threading;
using PetBookApp.Helpers;
using Fusillade;

namespace PetBookApp.Services
{
    public class ApiManager : IApiManager
    {
        IUserDialogs userDialogs = UserDialogs.Instance;
        IConnectivity connectivity = CrossConnectivity.Current;
        public bool IsConnected { get; set; }
        public bool IsReachable { get; set; }
        IApiService<IWeatherApi> getWeatherApi;
        Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
        Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();
        public ApiManager(IApiService<IWeatherApi> _getWeatherApi)
        {
            getWeatherApi = _getWeatherApi;
            IsConnected = connectivity.IsConnected;
            connectivity.ConnectivityChanged += OnConnectivityChanged;
        }


        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
            {
                var items = runningTasks;
                foreach(var item in items)
                {
                    item.Value.Cancel();
                    runningTasks.Remove(item.Key);
                }
            }
        }

        public async Task<HttpResponseMessage> GetWeather(string city)
        {
            var cts = new CancellationTokenSource();
            var task = RemoteRequestAsync<HttpResponseMessage>(getWeatherApi.GetApi(Priority.UserInitiated).GetWeather(city));
            runningTasks.Add(task.Id, cts);

            return await task;
        }

        protected async Task<TData> RemoteRequestAsync<TData> (Task<TData> task)
            where TData : HttpResponseMessage,
            new()
        {
            TData data = new TData();

            if (!IsConnected)
            {
                var strngResponse = "There's not a network connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            IsReachable = await connectivity.IsRemoteReachable(Config.ApiHostName);

            if (!IsReachable)
            {
                var strngResponse = "There's not a internet connection";
                data.StatusCode = HttpStatusCode.BadRequest;
                data.Content = new StringContent(strngResponse);

                userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(1));
                return data;
            }

            data = await Policy
                .Handle<WebException>()
                .Or<ApiException>()
                .Or<TaskCanceledException>()
                .WaitAndRetryAsync(
                    retryCount: 1,
                    sleepDurationProvider: retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttemp))
                ).ExecuteAsync(async () =>
                {
                    var result = await task;

                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {

                    }

                    return result;
                });

            return data;
        }
    }

    public interface IApiManager
    {
        Task<HttpResponseMessage> GetWeather(string city);
    }
}
