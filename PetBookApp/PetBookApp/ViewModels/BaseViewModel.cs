using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Prism;
using Prism.Navigation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation.TabbedPages;
using PetBookApp.Services;
using PetBookApp.Helpers;
using Acr.UserDialogs;
using System.Diagnostics;

namespace PetBookApp.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        private INavigationService _navigationService;
      

        public bool IsBusy { get; set; }

        public bool IsNotBusy
        {
            get { return !IsBusy; }
        }


        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
         
        }

 
        protected Task NavigateAsync(Uri page)
        {
           return _navigationService.NavigateAsync(page);
        }

        protected Task NavigateAsync(string page)
        {
            return _navigationService.NavigateAsync(page);
        }

        protected Task GoBackAsync()
        {
            return _navigationService.GoBackAsync();
        }

        protected Task GoBackToRootAsync()
        {
            return _navigationService.GoBackToRootAsync();
        }

        protected Task<INavigationResult> SelectTab(string page)
        {
            return _navigationService.SelectTabAsync(page);
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        
    }
}
