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
    public class BaseViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public IApiManager ApiManager;
        private INavigationService _navigationService;
        //IApiService<IWeatherApi> getWeatherApi = new ApiService<IWeatherApi>(Config.ApiUrl);
        private bool _isBusy;

        public bool IsBusy {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, () => RaisePropertyChanged(nameof(IsNotBusy))); }
        }

        public bool IsNotBusy
        {
            get { return !IsBusy; }
        }


        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //ApiManager = new ApiManager(getWeatherApi);
        }

        //public async Task RunSafe(Task task, bool ShowLoading = true, string loadingMessage = null)
        //{
        //    try
        //    {
        //        if (IsBusy) return;

        //        IsBusy = true;

        //        if (ShowLoading) UserDialogs.Instance.ShowLoading(loadingMessage ?? "Loading");
        //    } catch(Exception e)
        //    {
        //        IsBusy = false;
        //        UserDialogs.Instance.HideLoading();
        //        Debug.WriteLine(e.ToString());
        //        await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection", "Ok");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //        if (ShowLoading) UserDialogs.Instance.HideLoading();
        //    }
        //}

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }


    }
}
