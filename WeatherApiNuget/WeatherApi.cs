using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static WeatherApiNuget.JsonClasses;

namespace WeatherApiNuget
{
    public class WeatherApi : IWeatherApi
    {
        readonly WeatherApiOptions _weatherApiOptions;

        public WeatherApi(IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _weatherApiOptions = weatherApiOptions.Value;
        }

        public async Task<string> GetCurrentWeather(string cityName, bool isCelius=true)
        {

            Temperatures jsonData = new Temperatures();
            string responseBody = "";
                string res = "";

            Dictionary<string, string> weatherAttributes = new Dictionary<string, string>();
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync($"http://api.weatherapi.com/v1/current.json?key={_weatherApiOptions.ApiKey}&q={cityName}&aqi=no\r\n");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem API connection");
            }


            if (responseBody != null)
            {
                jsonData = JsonConvert.DeserializeObject<Temperatures>(responseBody);
            }



            if (isCelius == true)
            {
                res = jsonData.Current.TempC.ToString();
            }
            else
            {
                res = jsonData.Current.TempF.ToString();
            }
            return res;

        }
    }
}
