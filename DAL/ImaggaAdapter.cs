using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    /// <summary>
    /// This class is for connecting to the server
    /// </summary>
    public class ImaggaAdapter
    {
        /// <summary>
        /// get the image information
        /// </summary>
        /// <param name="RImage">the image info</param>
        /// <returns></returns>
        public string GetImageInformation(string RImage)
        {
            string apiKey = "acc_4858251230dcb88";
            string apiSecret = "c2f19534f3e9c73697368ef9cfe0cae1";
            //string imageUrl = "https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
            var client = new RestClient("https://api.imagga.com/v2/tags");

            var request = new RestRequest(new Uri("https://api.imagga.com/v2/tags"), Method.Get);

            if(RImage.StartsWith("http")==true)
            {
                request.AddParameter("image_url", RImage);
            }
            else
            {
                request.AddParameter("image_upload_id", RImage);
            }

            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            RestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
