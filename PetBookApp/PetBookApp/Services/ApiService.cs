using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetBookApp.Helpers;
using PetBookApp.Models;
using Refit;

namespace PetBookApp.Services
{
    class ApiService : IAuthenticationApi, IPetbookApi
    {
        public async Task AddPetAsync(Pet pet)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.GetTokenString());
            var json = await client.GetStringAsync(
            $"{Config.ApiUrl}/api/values");
            var values = JsonConvert.DeserializeObject<List<string>>(json);
        }

        public async Task<Token> Login(List<KeyValuePair<string,string>> userData)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{Config.ApiUrl}/Token");
            request.Content = new FormUrlEncodedContent(userData);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Token myUserToken = JsonConvert.DeserializeObject<Token>(content);

            if (!(myUserToken == null))
            {
                App.Current.Properties["TokenString"] = myUserToken.AccessToken;
                App.Current.Properties["UserToken"] = myUserToken;
            }
            return myUserToken;
        }

        public async Task RegisterUserAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(
                $"{Config.ApiUrl}/api/Account/Register", httpContent);
        }
    }
}
