using System;
using RestSharp;

namespace DAL
{
    public class HebCalAdapter
    {
        public string GetCommingHoliday(DateTime CurrentDate)
        {
            String startDate;
            //if (CurrentDate.Month<10)
            //    startDate+= $"0{CurrentDate.Month}-{CurrentDate.Day}";
            //else 
            //    startDate += $"{CurrentDate.Month}-{CurrentDate.Day}";
            //if (CurrentDate.Day < 10)
            //    if (CurrentDate.Day < 10)
            int monthInt = CurrentDate.Month;
            string month = monthInt.ToString("D2");
            int dayInt = CurrentDate.Day;
            string day = dayInt.ToString("D2");
            startDate = $"{CurrentDate.Year}-{month}-{day}";

            string Url = $"https://www.hebcal.com/converter?cfg=json&date={startDate}&g2h=1&strict=1";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);
            

            return response.Content;
            

        }
    }
}
