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
        public string WhatWeather(string city = "Jerusalem")
        {
          
            Root myWeather = null;
            DAL.WeatCalAdapter dal = new DAL.WeatCalAdapter(); // here is the call to the Data layer
            string myJson = dal.GetWeather(city);
            if (myJson != null)
            {
                myWeather = JsonConvert.DeserializeObject<Root>(myJson); // retrieve the data from the json
            }
           
            double weather = myWeather.main.feels_like;
            string result;
            // according the weather determine the category of weather
            if(weather <= 15)
            {
                result = $"Cold {weather}";
            } 
            else if(weather <= 27)
            {
                result = $"Nice {weather}";
            }
            else 
            {
                result = $"Hot {weather}";
            } 
            

            return $"{weather}";
        }
    }
}
