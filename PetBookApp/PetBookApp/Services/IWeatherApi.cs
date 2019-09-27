using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetBookApp.Services
{
    [Headers("Content-Type: application/json")]
    public interface IWeatherApi
    {
        [Get("data/2.5/weather?q={city}")]
        Task<HttpResponseMessage> GetWeather(string city);

    }
}
