using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Media;
using Prism.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Xamarin.Forms;

namespace PetBookApp.Helpers
{
    public class MediaHelper
    {
        public MediaFile _mediaFile;
        public string URL { get; set; }

        protected IPageDialogService _dialogService;
        public MediaHelper(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        public async Task<Stream> PickAPhotoAsync()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await _dialogService.DisplayAlertAsync("Error", "This is not supported on your device.", "OK");
                return null;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return null;

                return _mediaFile.GetStream();

               
            }

        }

        public async Task<Stream> TakeAPictureAsync()
        {

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _dialogService.DisplayAlertAsync("No Camera", ":(No Camera available.)", "OK");
                return null;
            }
            else
            {
                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "myImage.jpg"
                });

                if (_mediaFile == null) return null;
                return _mediaFile.GetStream();
            }

        }

        public async Task  UploadImage()
        {
            
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=marcosblob;AccountKey=s8xqEiEOaiBXuE7ZwzNF6jsxs9fxKyVWo1ZtYjiwjkeJOmR7tFmyoNAf1NSy8DYDoiPgPqPhCVlqlewZ+JMpkw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("xamarin-blob");
            await container.CreateIfNotExistsAsync();
            var name = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{name}.png");
            await blockBlob.UploadFromStreamAsync(_mediaFile.GetStream());
            URL = blockBlob.Uri.OriginalString;           
          
        }

    }
}
