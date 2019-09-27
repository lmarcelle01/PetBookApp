using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class OnBoardingPageViewModel : BaseViewModel
    {

        public DelegateCommand GoToSignInPageCommand { get; set; }

        public DelegateCommand GoToSignUpPageCommand { get; set; }
        public OnBoardingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToSignInPageCommand = new DelegateCommand(async () =>
            {
                await GoToSignIn();

            });

            GoToSignUpPageCommand = new DelegateCommand(async () =>
            {
                await GoToSignUp();

            });
        }
        async Task GoToSignIn()
        {
            await NavigateAsync(Constants.GoToSignInPage);
        }

        async Task GoToSignUp()
        {
            await NavigateAsync(Constants.GoToSignUpPage);
        }


    }
}
