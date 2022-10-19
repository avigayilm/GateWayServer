using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;
using DP;
using Newtonsoft.Json;
using static DP.HebCalModel;

namespace BL
{
    public class HebCalLogic
    {

        public HebCalClass isHoliday(DateTime currentDate)
        {
            string HebDate;
            int day;
            string month;
            Holiday? holiday = null;
            Root myHoliday = null;
            DAL.HebCalAdapter dal = new DAL.HebCalAdapter();
            
            string myJson = dal.GetCommingHoliday(currentDate);
            if (myJson != null)
            {
                myHoliday = JsonConvert.DeserializeObject<Root>(myJson);
            }
            month = myHoliday.hm;
            day = myHoliday.hd;
            HebDate = myHoliday.hebrew;


            //return month;

            switch (month)
            {
                case "Ellul":
                    holiday = Holiday.Rosh_Hashana;
                    break;// call fuction for rosh hashana receipes

                case "Tishrei":
                    {
                        if (day > 0 && day < 22)
                        {
                            holiday = Holiday.Succot;
                            break;// call funciton for sukkot 
                        }
                        //if (day > 17 & day < 22)
                        //{
                        //    holiday=Holiday.sim
                        //    break;// call function for simchat torah
                        //}
                        // default function to calculate for the english date
                        break;
                    }

                case "Kislev":
                    holiday = Holiday.Hannuka;
                    break;// call for hanukka calling

                case "Tevet":
                    if (day < 4)
                    {
                        holiday = Holiday.Hannuka;
                        break;// call hanukka function
                    }
                    break;


                case "shvat":
                    if (day > 7 && day < 16)
                    {
                        holiday = Holiday.Tubishvat;
                        break;// call tu bishvat function
                    }
                    break;

                case "Adar":
                    if (day < 16)
                    {
                        holiday=Holiday.Purim;
                        break;// call the Purim function
                    }
                    else
                    {
                        holiday = Holiday.Pesach;
                        break;// Pesach funciton
                    }  
                case "Nissan":
                    if (day < 21)
                    {
                        holiday=Holiday.Pesach;
                        break;// pesach functoin
                    }

                    break;
                case "Iyar":
                    if (day == 4 || day == 5 || day == 17 || day == 18)
                    {
                        holiday = Holiday.Lagbaomer;
                        break;// lag baomer bbq
                    }
                    break;
                case "Sivan":
                    if (day < 6)
                    {
                        holiday = Holiday.Shavouot;
                        break;// shavuot
                    }
                    break;
                case "Tammuz":
                    break;
                case "Av":
                    break;
            }
            if (holiday == null)
                holiday = Holiday.None;
            HebCalClass HebCal = new HebCalClass() { Holiday = holiday, HebrewDate = HebDate, number = day, Month = month };
            return HebCal;
            //return "hi";


        }
    }
}