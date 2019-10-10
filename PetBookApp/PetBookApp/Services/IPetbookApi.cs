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
       
       Task AddPetAsync(Pet pet);
    }
    
    public interface IAuthenticationApi
    { 
        Task RegisterUserAsync(User user);
        
        Task<Token> Login(List<KeyValuePair<string,string>> userData);

    }
}