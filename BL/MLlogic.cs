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
    public class MLlogic
    {/// <summary>
     ///gets from the dal the prediction and retrieves only the higher probability predictions
     /// </summary>
     /// <returns>only what the weather 'feels like' in celsius</returns>
        // I could add a function for all the prediction but seems pointless for our usage
        public string Prediction(string weather, string holiday, string lastCat)
        {
            DAL.MLAdapter dal = new DAL.MLAdapter();
            string predict = dal.Predict(lastCat, weather, holiday).Result;
            return predict;
        }
    }
}

