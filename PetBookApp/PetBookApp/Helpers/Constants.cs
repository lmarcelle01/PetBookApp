using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Helpers
{
    public static class Constants
    {
        public static string GoToGettingStartedPage = "/GettingStartedPage";
        public static string GoToOnBoardingPage = "NavigationPage/OnBoardingPage";
        public static Uri GoToHome = new Uri("NavigationPage/HomeTabbedPage/HomePage", UriKind.Relative);
        public static Uri GoToHomeTabbedPage = new Uri("HomeTabbedPage", UriKind.RelativeOrAbsolute);
        public static Uri GoToPostImagePage = new Uri("PostImagePage", UriKind.Relative);
        public static Uri GoToPostTextPage = new Uri("PostTextPage", UriKind.Relative);
        public static Uri GoToPostDetailPage = new Uri("PostDetailPage", UriKind.Relative);
        public static Uri GoToAddPetPage = new Uri("AddPetPage", UriKind.Relative);
        public static Uri GoToProfilePage = new Uri("HomeTabbedPage/ProfilePage", UriKind.Relative);
        public static Uri GoToSignInPage = new Uri("SignInPage", UriKind.Relative);
        public static Uri GoToSignUpPage = new Uri("SignUpPage", UriKind.Relative);
        public static Uri GoToSignUpPetPage = new Uri("SignUpPetPage", UriKind.Relative);
        public static Uri GoToFinderPage = new Uri("FinderPage", UriKind.Relative);
        public static Uri GoToSettingsPage = new Uri("SettingsPage", UriKind.Relative);
    }
}
