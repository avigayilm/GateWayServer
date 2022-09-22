using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DP.WeatCalModel;
//using System.Device.Location;


namespace BL
{
    public class WeatCalLogic
    {
        public string WhatWeather()
        {
          
            Root myWeather = null;
            DAL.WeatCalAdapter dal = new DAL.WeatCalAdapter();
            string myJson = dal.GetWeather();
            if (myJson != null)
            {
                myWeather = JsonConvert.DeserializeObject<Root>(myJson);
            }
           
            double weather = myWeather.main.feels_like;

            return $"{weather}";
        }
    }
}
