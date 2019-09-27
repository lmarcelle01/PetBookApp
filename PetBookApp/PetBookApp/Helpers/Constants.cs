using System;
using System.Collections.Generic;
using System.Text;

namespace PetBookApp.Helpers
{
    public static class Constants
    {
        public static Uri GoToHome = new Uri("HomePage", UriKind.Relative);
        public static Uri GoToHomeTabbedPage = new Uri("HomeTabbedPage");
        public static Uri GoToGettingStartedPage = new Uri("GettingStartedPage", UriKind.Absolute);
        public static Uri GoToPostImagePage = new Uri("PostImagePage", UriKind.Relative);
        public static Uri GoToPostTextPage = new Uri("PostTextPage", UriKind.Relative);
        public static Uri GoToPostDetailPage = new Uri("PostDetailPage", UriKind.Relative);
        public static Uri GoToAddPetPage = new Uri("AddPetPage", UriKind.Relative);
        public static Uri GoToOnBoardingPage = new Uri("OnBoardingPage", UriKind.Absolute);
        public static Uri GoToProfilePage = new Uri("ProfilePage", UriKind.Relative);
        public static Uri GoToSignInPage = new Uri("SignInPage", UriKind.Relative);
        public static Uri GoToSignUpPage = new Uri("SignUpPage", UriKind.Relative);
        public static Uri GoToSignUpPetPage = new Uri("SignUpPetPage", UriKind.Relative);
        public static Uri GoToFinderPage = new Uri("FinderPage", UriKind.Relative);
    }
}
