using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public DelegateCommand SignOutCommand { get; set; }
        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SignOutCommand = new DelegateCommand(async () =>
            {
                await SignOut();

            });
        }

        async Task SignOut()
        {
            await NavigateAsync(Constants.GoToOnBoardingPage);
        }

    }
}
