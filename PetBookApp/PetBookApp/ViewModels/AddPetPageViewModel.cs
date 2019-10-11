using PetBookApp.Helpers;
using PetBookApp.Models;
using PetBookApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PetBookApp.ViewModels
{
    public class AddPetPageViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MediaHelper MediaHelper { get; set; }
        public DelegateCommand AddPetCommand { get; set; }
        public Pet NewPet { get; set; }
        protected IPageDialogService _dialogService { get; set; }
        public ImageSource ImageSource { get; set; }    
        public DelegateCommand AddProfilePictureCommand { get; set; }

        public IPetbookApi ApiService { get; set; }

        public AddPetPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            NewPet = new Pet();
            ApiService = new ApiService();
            ImageSource = ImageSource.FromUri(new Uri("https://icon-library.net/images/pet-icon-png/pet-icon-png-25.jpg"));
            _dialogService = dialogService;
            MediaHelper = new MediaHelper(dialogService);

            AddPetCommand = new DelegateCommand(async () =>
            {
                await AddPetAsync();
            });

            AddProfilePictureCommand = new DelegateCommand(async () =>
            {
                await AddProfilePicture();
            });
        }

   

        public async Task AddPetAsync()
        {

            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {

                    await MediaHelper.UploadImage();
                    NewPet.ProfileImageUrl = MediaHelper.URL;
                    Token currentUserToken = Config.GetToken();
                    if (currentUserToken != null)
                    {
                        NewPet.UserId = currentUserToken.UserId;
                        await ApiService.AddPetAsync(NewPet);
                        await _dialogService.DisplayAlertAsync("Yay!", "Pet added sucessfully", "Ok");
                    }
                    else
                    {
                        await _dialogService.DisplayAlertAsync("You're not signed in", "Please sign in again", "Ok");
                        await NavigateAsync(Constants.GoToSignInPage);
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Unable to connect to the server", "Ok");
            }

        }

        public async Task AddProfilePicture()
        {
          
            Stream newImgSource;
            string action = await _dialogService.DisplayActionSheetAsync("Select an option", "Cancel", null, "Pick photo from gallery", "Take a photo");
            switch (action)
            {
                case "Pick photo from gallery":
                    newImgSource = await MediaHelper.PickAPhotoAsync();
                    if (newImgSource != null)
                        ImageSource = ImageSource.FromStream(() => newImgSource);
                    break;
                case "Take a photo":
                    newImgSource = await MediaHelper.TakeAPictureAsync();
                    if (newImgSource != null)
                        ImageSource = ImageSource.FromStream(() => newImgSource);
                    break;
            }

        }

        

    }
}
