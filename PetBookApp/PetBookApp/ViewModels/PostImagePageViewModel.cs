using PetBookApp.Helpers;
using PetBookApp.Models;
using PetBookApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
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
    public class PostImagePageViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MediaHelper MediaHelper { get; set; }
        protected IPageDialogService _dialogService { get; set; }
        public Post Post { get; set; }
        public DelegateCommand AddPictureCommand { get; set; }
        public Post NewPost { get; set; }
        public IPetbookApi ApiService { get; set; }
        public ImageSource ImageSource { get; set; }

        public List<Pet> UserPets { get; set; }

        Pet pet;
        public Pet SelectedPet
        {
            get
            {
                return pet;
            }
            set
            {
                pet = value;

                if (pet != null)
                    OnSelectItem(pet);

            }
        }



        public DelegateCommand AddPostCommand { get; set; }
        public PostImagePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {

            MediaHelper = new MediaHelper(dialogService);
            NewPost = new Post();
            _dialogService = dialogService;
            ApiService = new ApiService();

            AddPictureCommand = new DelegateCommand(async () =>
            {
                await AddPicture();
            });

            AddPostCommand = new DelegateCommand(async () =>
            {
                await AddPostAsync();
            });
            LoadUserPets();
            

        }

        public async Task AddPostAsync()
        {

            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {

                    await MediaHelper.UploadImage();
                    NewPost.ImageUrl = MediaHelper.URL;
                    Token currentUserToken = Config.GetToken();
                    if (currentUserToken != null)
                    {
                        NewPost.UserId = currentUserToken.UserId;
                        NewPost.ContentText = "";
                        await ApiService.PostAPostAsync(NewPost);
                        await _dialogService.DisplayAlertAsync("Yay!", "Your post has been saved", "Ok");
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
        public async Task AddPicture()
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

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadUserPets();
        }

        void OnSelectItem(Pet pet)
        {
            NewPost.PetId = pet.PetID;
        }

        async void LoadUserPets()
        {
            if (Config.GetToken() != null)
            {
                UserPets = await ApiService.GetUserPetsAsync(Config.GetToken().UserId);
                if (UserPets.Count <= 0)
                {
                    await _dialogService.DisplayAlertAsync("You don't have pets", "Please add a pet to post with", "Ok");
                    await NavigateAsync(Constants.GoToAddPetPage);
                }
            }
            else
            {
                await _dialogService.DisplayAlertAsync("You're not signed in", "Please sign in again", "Ok");
                await NavigateAsync(Constants.GoToSignInPage);
            }
        }

    }
}
