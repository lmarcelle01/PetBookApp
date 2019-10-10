using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetBookApp.Helpers;
using PetBookApp.Models;
using Refit;

namespace PetBookApp.Services
{
    class ApiService : IAuthenticationApi, IPetbookApi
    {
        public async Task AddPetAsync([Body] Pet pet)
        {
            var apiResponse = RestService.For<IPetbookApi>(Config.ApiUrl);
            await apiResponse.AddPetAsync(pet);
        }

        public async Task<Token> Login([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data)
        {
            var authenticationApi = RestService.For<IAuthenticationApi>(Config.ApiUrl);
            Token myUserToken = await authenticationApi.Login(data);

            if(!(myUserToken == null))
            {
                App.Current.Properties["TokenString"] = myUserToken.AccessToken;
                App.Current.Properties["UserToken"] = myUserToken;
            }
            return myUserToken;
        }

        public async Task<string> RegisterUserAsync([Body] User user)
        {
            var authenticationApi = RestService.For<IAuthenticationApi>(Config.ApiUrl);
            var userId = await authenticationApi.RegisterUserAsync(user);

            return userId;
               
        }
    }
}
