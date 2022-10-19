using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    [Serializable]
    public class WeatherParamsDTO
    {
        //public double Lon { get; set; }
        //public double Lat { get; set; }
        public string City { get; set; }
    }

    public class WeatherClass
    {
        public double Temp { get; set; }
        public Weather  WeatherFeel { get; set; }
    }
    public enum Weather { None, Hot, Regular, Cold }
}
