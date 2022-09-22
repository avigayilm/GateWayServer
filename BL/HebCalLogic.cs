using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static DP.HebCalModel;

namespace BL
{
    public class HebCalLogic
    {

        public string isHoliday(DateTime currentDate)
        {
            string holiday;
            int day;
            string month;
            Root myHoliday = null;
            DAL.HebCalAdapter dal = new DAL.HebCalAdapter();
            
            string myJson = dal.GetCommingHoliday(currentDate);
            if (myJson != null)
            {
                myHoliday = JsonConvert.DeserializeObject<Root>(myJson);
            }
            month = myHoliday.hm;
            day = myHoliday.hd;

            return month;

            //switch (month)
            //{
            //    case "Ellul":
            //        break;// call fuction for rosh hashana receipes

            //    case "Tishrei":
            //        {
            //            if (day > 2 && day < 18)
            //                break;// call funciton for sukkot 
            //            if (day > 17 & day < 22)
            //                break;// call function for simchat torah
            //                      // default function to calculate for the english date
            //            break;
            //        }

            //    case "Kislev":
            //        break;// call for hanukka calling

            //    case "Tevet":
            //            if (day < 4)
            //                break;// call hanukka function
            //        break;


            //    case "shvat":
            //        if (day > 7 && day < 16)
            //            break;// call tu bishvat function
            //        break;

            //    case "Adar":
            //        if (day < 16)
            //            break;// call the Purim function
            //        else
            //            break;// Pesach funciton
            //        break;
            //    case "Nissan":
            //        if (day < 21)
            //            break;// pesach functoin
            //        break;
            //    case "Iyar":
            //        if (day == 4 || day == 5 || day == 17 || day == 18)
            //            break;// lag baomer bbq
            //        break;
            //    case "Sivan":
            //        if (day < 6)
            //            break;// shavuot
            //        break;
            //    case "Tammuz":
            //    case "Av":
            //        break;
            //}
            //return "hi";


        }
    }
}