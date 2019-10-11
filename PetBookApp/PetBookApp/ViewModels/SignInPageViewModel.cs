using PetBookApp.Helpers;
using PetBookApp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PetBookApp.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {
        public DelegateCommand LogInCommand { get; set; }

        public User User { get; set; }

        public IAuthenticationApi apiService;
        public SignInPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new User();
            apiService = new ApiService();
            LogInCommand = new DelegateCommand(async () =>
            {
                await LogInAsync();

            });
        }

        async Task LogInAsync()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {

                    var userData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("UserName", User.Email),
                        new KeyValuePair<string, string>("password", User.Password),
                        new KeyValuePair<string, string>("grant_type", "password")
                    };

                    
                    IsBusy = false;
                    await apiService.Login(userData);
                    if(Config.GetToken() != null)
                    {
                        await NavigateAsync(Constants.GoToHomeTabbedPage);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "It seems like the information you gave us is not correct, please try again.", "Ok");
                    }
                   
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Unable to connect to the server", "Ok");
            }

        }

    }
}
