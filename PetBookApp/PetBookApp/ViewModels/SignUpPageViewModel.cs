using PetBookApp.Helpers;
using PetBookApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {

        public DelegateCommand RegisterUserCommand { get; set; }
        public User NewUser { get; set; }

        public IAuthenticationApi apiService;
        public IPetbookApi PetbookApi;
        public  SignUpPageViewModel(INavigationService navigationService) :base(navigationService)
        {
            apiService = new ApiService();
            NewUser = new User();
            PetbookApi = new ApiService();
            RegisterUserCommand = new DelegateCommand(async () =>
            {
                await RegisterUser();
            });

        }

        async Task RegisterUser()
        {
            NewUser.ProfileImageUrl = "";
            await apiService.RegisterUserAsync(NewUser);

            var userData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", NewUser.Email),
                new KeyValuePair<string, string>("password", NewUser.Password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            Token getToken = await apiService.Login(userData);

            await NavigateAsync(Constants.GoToAddPetPage);

        }
       

    }
}
