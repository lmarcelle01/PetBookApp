using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PetBookApp.ViewModels
{
    public class GettingStartedPageViewModel : BaseViewModel
    {
        public DelegateCommand HomeTabbedPage { get; set; }
        public GettingStartedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            HomeTabbedPage = new DelegateCommand(async() =>
            {
                await NavigateAsync(Constants.GoToHomeTabbedPage);
            });

        }
    }
}
