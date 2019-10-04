using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PetBookApp.Helpers
{
    public static class Config
    {
        private const string Pattern = @"^?http(?:s)?://?(?:www(?:[0-9]+]?\.";
        public static string ApiUrl = "http://api.openweathermap.org";
        public static string ApiKey = "";

        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, Pattern, string.Empty, RegexOptions.IgnoreCase)
                    .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
