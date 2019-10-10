using PetBookApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace PetBookApp.Helpers
{
    public static class Config
    {     
        public static string ApiUrl = "https://petbookbackend20191008113748.azurewebsites.net";

        public static string GetTokenString()
        {
            if (!(App.Current.Properties["TokenString"] == null))
            {
                return App.Current.Properties["TokenString"].ToString();
            }
            else
            {
                return "";
            }
        }
        
    }
}
