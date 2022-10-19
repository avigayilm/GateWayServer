using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DP.WeatCalModel;
//using System.Device.Location;


namespace BL
{
    /// <summary>
    /// the BL weather class
    /// </summary>
    public class WeatCalLogic
    {/// <summary>
    ///gets from the dal the weather and retrieves only the 'feels like' tag
    /// </summary>
    /// <returns>only what the weather 'feels like' in celsius</returns>
        public WeatherClass WhatWeather(string city = "Jerusalem")
        {
          
            Root myWeather = null;
            DAL.WeatCalAdapter dal = new DAL.WeatCalAdapter(); // here is the call to the Data layer
            string myJson = dal.GetWeather(city);
            if (myJson != null)
            {
                myWeather = JsonConvert.DeserializeObject<Root>(myJson); // retrieve the data from the json
            }
           
            double weatherDegree = myWeather.main.feels_like;
            DP.Weather result;
            // according the weather determine the category of weather
            if(weatherDegree <= 15)
            {
                result = DP.Weather.Cold;
            } 
            else if(weatherDegree <= 27)
            {
                result = DP.Weather.Regular;
            }
            else 
            {
                result = DP.Weather.Hot;
            }

            WeatherClass weatherRes = new WeatherClass() { Temp = weatherDegree, WeatherFeel = result };
            return weatherRes;
        }
    }
}
