using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class SignUpPetPageViewModel
    {
        protected INavigationService _navigationService;
        public DelegateCommand GoToSignUpPetCommand { get; set; };

        public SignUpPetPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToSignUpPetCommand = new DelegateCommand(async () =>
            {
                await GoToHomeTabbed();
            });
        }

        async Task GoToHomeTabbed()
        {
            await _navigationService.NavigateAsync(Constants.GoToSignUpPetPage);
        }
    }
}
