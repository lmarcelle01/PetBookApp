using Newtonsoft.Json;
using PetBookApp.Helpers;
using PetBookApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PetBookApp.Models;

namespace PetBookApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();

        public event EventHandler IsActiveChanged;

        protected IPageDialogService _dialogService;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        public DelegateCommand DisplayPostActionSheetCommand { get; set; }


        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            DisplayPostActionSheetCommand = new DelegateCommand(async () =>
            {
                await DisplayPostActionSheet();

            });

            for (int i = 0; i < 5; i++)
            {
                var post = new Post();
                post.PetId = i;
                post.UserId = (i+1).ToString();
                if (i % 2 == 0)
                    post.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/de/Desenka_meadow_2016_G1.jpg/500px-Desenka_meadow_2016_G1.jpg";
                else
                    post.ContentText = "Jose tiene un sapito que se llama lolo wuwuwuwuwuwwuwuwuwuwuwuwuwuwuwuwuwuwwuwu";
                Posts.Add(post);
            }

            //FetchWeather = new DelegateCommand(async () =>
            //{
            //    await RunSafe(GetWeather(city.Name));
            //});

            
        }

        //async Task GetWeather(string city)
        //{
        //    //var apiResponse = RestService.For<IWeatherApi>(Config.ApiUrl);
        //    //var weather = await apiResponse.GetWeather(city);

        //    var weatherResponse = await ApiManager.GetWeather(city);

        //    if (weatherResponse.IsSuccessStatusCode)
        //    {
        //        var response = await weatherResponse.Content.ReadAsStringAsync();
        //        var json = await Task.Run(() => JsonConvert.DeserializeObject<Weather>(response));
        //    }
        //    else
        //    {
        //        await _dialogService.DisplayAlertAsync("Unable to get adata", "Error", "Ok");
        //    }



        //    //return weather;
        //}

        //async void SelectTab(object parameters)
        //{
        //    var result = await base.SelectTab("PROFILE");
        //}

        async Task DisplayPostActionSheet()
        {
            string action = await _dialogService.DisplayActionSheetAsync("Select an option", "Cancel", null, "Post text", "Post image");
            switch (action)
            {
                case "Post text":
                    await NavigateAsync(Constants.GoToPostTextPage);
                    break;
                case "Post image":
                    await NavigateAsync(Constants.GoToPostImagePage);
                    break;
            }
        }
    }
}
