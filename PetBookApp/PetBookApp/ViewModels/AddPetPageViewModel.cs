using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.ViewModels
{
    public class AddPetPageViewModel : BaseViewModel
    {
        public DelegateCommand AddPetCommand { get; set; }
        public AddPetPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddPetCommand = new DelegateCommand(async () =>
            {
                await GoBackAsync();
            });
        }


    }
}
