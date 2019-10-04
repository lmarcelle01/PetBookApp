using PetBookApp.ViewModels;
using PetBookApp.Views.Components;
using PetBookApp.Views.GettingStarted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetBookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStartedPage : ContentPage
    {
        private View[] _views;
        public GettingStartedPage()
        {
            InitializeComponent();
            _views = new View[]
            {
                new FirstView(),
                new SecondView(),
                new ThirdView(),
                new FourthView()
            };

            Carousel.ItemsSource = _views;
        }

        private void OnCarouselPositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            var currentView = _views[e.NewValue];

            if (currentView is IAnimatedView animatedView)
            {
                animatedView.StartAnimation();
            }
        }
    }
}