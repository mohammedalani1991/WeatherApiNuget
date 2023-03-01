using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiNuget
{
    public interface IWeatherApi
    {
        public Task<string> GetCurrentWeather(string cityName, bool isCelius=true);
    }
}
