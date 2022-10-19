using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    [Serializable]
    public class HebCalParamsDTO
    {
        public DateTime CurrentDate { get; set; }

    }

    public class HebCalClass
    {
        public Holiday? Holiday { get; set; }
        public int number { get; set; }

        public string HebrewDate { get; set; }
        public string Month { get; set; } 
    }

    public enum Holiday { None, Rosh_Hashana, Yom_Kippur, Succot, Shmini_Atzeret, Hannuka, Tubishvat, Purim, Pesach, Shavouot, Lagbaomer }

}
