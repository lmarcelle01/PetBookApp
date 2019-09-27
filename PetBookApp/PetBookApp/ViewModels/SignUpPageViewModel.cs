using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {

        protected INavigationService _navigationService;

        public DelegateCommand GoToSignUpPetCommand { get; set; }
        public  SignUpPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToSignUpPetCommand = new DelegateCommand(async () =>
            {
                await GoToSignUpPet();

            });

        }

        async Task GoToSignUpPet()
        {
            await _navigationService.NavigateAsync(Constants.GoToHomeTabbedPage);
        }
       

    }
}
