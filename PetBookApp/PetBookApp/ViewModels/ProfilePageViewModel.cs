using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public DelegateCommand GoToSettingsCommand { get; set; }
        public DelegateCommand GoToAddPetCommand { get; set; }
        public ProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToSettingsCommand = new DelegateCommand(async () =>
            {
                await GoToSettingsPage();

            });

            GoToAddPetCommand = new DelegateCommand(async () =>
            {
                await GoToAddPetPage();

            });

        }

        async Task GoToSettingsPage()
        {
            await NavigateAsync(Constants.GoToSettingsPage);
        }

        async Task GoToAddPetPage()
        {
            await NavigateAsync(Constants.GoToAddPetPage);
        }

    }
}
