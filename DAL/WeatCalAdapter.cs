using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// the weather DL class for dealing with weather server
    ///
    /// </summary>
    public class WeatCalAdapter
    {
        /// <summary>
        /// here we connect to the remote openweather server and retrieve the weather of given city
        /// </summary>
        /// <param name="City"></param>
        /// <returns> returns all the weather data in celsius @returns all the weather data in celsius</returns>
        public string GetWeather(string city)
        {
            city = "Jerusalem";
           // var location = Usefuls.Location.GetLocationProperty();
            //double lon = location.Item2;
            //double lat = location.Item1;

            string Url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=9d542e14be75e524c11905e966f5c22b&units=metric";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);
           

            return response.Content;

        }
    }
}
