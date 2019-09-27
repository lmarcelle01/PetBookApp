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

namespace PetBookApp.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        protected Page page { get; private set; }
        private INavigationService _navigationService;
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
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected Task NavigateAsync(Uri page)
        {
           return _navigationService.NavigateAsync(page);
        }

        protected Task GoBackAsync()
        {
            return _navigationService.GoBackAsync();
        }

        protected Task GoBackToRoot(bool animate)
        {
            return _navigationService.GoBackToRootAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
