using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public class UsdaAdapter
    {
        // returns the JSon file with the nutrients
        public string GetNutrients(string ingredients)
        {
            

            string Url = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={ingredients}&pageSize=2&api_key=kQNXsVhdYahE0dDjIajFBgg42AsY8SUZNkRGQuRi"; 

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);


            return response.Content;


        }
    }
}
