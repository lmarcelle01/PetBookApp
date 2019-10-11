using Newtonsoft.Json;
using PetBookApp.Helpers;
using PetBookApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace PetBookApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public event EventHandler IsActiveChanged;

        protected IPageDialogService _dialogService;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        public DelegateCommand DisplayPostActionSheetCommand { get; set; }


        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            DisplayPostActionSheetCommand = new DelegateCommand(async () =>
            {
                await DisplayPostActionSheet();

            });

            async Task DisplayPostActionSheet()
            {
                string action = await _dialogService.DisplayActionSheetAsync("Select an option", "Cancel", null, "Post text", "Post image");
                switch (action)
                {
                    case "Post text":
                        await NavigateAsync(Constants.GoToPostTextPage);
                        break;
                    case "Post image":
                        await NavigateAsync(Constants.GoToPostImagePage);
                        break;
                }
            }
        }
    }
}
