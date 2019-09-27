using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using System;
using System.Collections.Generic;
using System.Text;

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
        public ProfilePageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        async void SelectTab(object parameters)
        {
            var result = await base.SelectTab("HOME");
        }
    }
}
