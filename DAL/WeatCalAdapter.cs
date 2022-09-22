﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class WeatCalAdapter
    {

        public string GetWeather(string City = "Jerusalem")
        {

            string Url = $"https://api.openweathermap.org/data/2.5/weather?q={City}&appid=9d542e14be75e524c11905e966f5c22b&units=metric";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);
           

            return response.Content;

        }
    }
}
