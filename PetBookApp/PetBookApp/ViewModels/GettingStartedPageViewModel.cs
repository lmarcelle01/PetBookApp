using PetBookApp.Helpers;
using PetBookApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetBookApp.ViewModels
{
    public class GettingStartedPageViewModel : BaseViewModel
    {
        public DelegateCommand HomeTabbedPage { get; set; }

        public ObservableCollection<Slide> Slides { get; set; }

        public GettingStartedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Slides = new ObservableCollection<Slide>()
            {
                new Slide("dog.json", "Create an individual profile for each pet!", 300, false, "Aqua"),
                new Slide("share.json", "Post your pet(s) pictures and share it with your friends, family and people all around the world", 150, false, "Magenta"),
                new Slide("event.json", "Create an event for your pet(s) to meet with others as yours!", 150, false, "Purple"),
                new Slide("community.json", "Be part of a non stop-stop growing community of pet lovers!", 150, true, "Pink")
            };

            

            HomeTabbedPage = new DelegateCommand(async() =>
            {
                await NavigateAsync(Constants.GoToHomeTabbedPage);
            });

        }
    }
}
