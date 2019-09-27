using PetBookApp.ViewModels;
using PetBookApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetBookApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPetPage, SignUpPetPageViewModel>();

            containerRegistry.RegisterForNavigation<GettingStartedPage, GettingStartedPageViewModel>();
            containerRegistry.RegisterForNavigation<PostImagePage, PostImagePageViewModel>();
            containerRegistry.RegisterForNavigation<PostTextPage, PostTextPageViewModel>();
            containerRegistry.RegisterForNavigation<PostDetailPage, PostDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<FinderPage, FinderPageViewModel>();

        }
    }
}
