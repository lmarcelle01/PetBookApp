using PetBookApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.Services
{
    [Headers("Bearer {Config.GetTokenString}")]
    public interface IPetbookApi
    {
        [Post("api/Pets")]
       Task AddPetAsync([Body]Pet pet);
    }
    
    public interface IAuthenticationApi
    {
        [Post("api/Account/Register")]
        Task<string> RegisterUserAsync([Body]User user);
        
        [Get("Token")]
        Task<Token> Login([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);

    }
}