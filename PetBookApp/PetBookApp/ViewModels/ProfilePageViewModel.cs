using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
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

        //async void SelectTab(object parameters)
        //{
        //    var result = await base.SelectTab("HOME");
        //}
    }
}
