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
       Task PostCommentAsync(Comment comment);
       Task LikePostAsync();
       Task PostAPostAsync(Post post);
       Task<List<Pet>> GetUserPetsAsync(string userId);
       Task<List<Comment>> GetPostCommentsAsync();
       Task<List<Post>> GetAllPostsAsync();
       Task AddPetAsync(Pet pet);
    }
    
    public interface IAuthenticationApi
    { 
        Task RegisterUserAsync(User user);
        
        Task<Token> Login(List<KeyValuePair<string,string>> userData);

    }
}