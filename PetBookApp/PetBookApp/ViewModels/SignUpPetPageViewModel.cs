﻿using PetBookApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.ViewModels
{
    public class SignUpPetPageViewModel : BaseViewModel
    {
        public DelegateCommand GoToGettingStartedCommand { get; set; }
        public SignUpPetPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToGettingStartedCommand = new DelegateCommand(async () =>
            {
                await GoToGettingStartedPage();

            });

        }
        async Task GoToGettingStartedPage()
        {
            await NavigateAsync(Constants.GoToGettingStartedPage);
        }

    }
}
