using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {

        public DelegateCommand GoToHomeTabbedCommand { get; set; }
        public SignInPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToHomeTabbedCommand = new DelegateCommand(async () =>
            {
                await GoToHomeTabbed();

            });
        }

        async Task GoToHomeTabbed()
        {
            await NavigateAsync(Constants.GoToHomeTabbedPage);
        }

    }
}
