using DP;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET: api/<WeatherController>
        /// <summary>
        /// recieves from businuss layer what the weather is
        /// </summary>
        /// <returns>what the weather category is</returns>
        //[HttpGet]
        //public string Get()
        //{
        //    BL.WeatCalLogic bl = new();
        //    double jerusalemLat = 31.771959;
        //    double jerusalemLon = 35.217018;
        //    string result = bl.WhatWeather(jerusalemLon, jerusalemLat);
        //    return result;
        //}
        [HttpGet]
        public WeatherClass Get([FromQuery]WeatherParamsDTO  data)
        {
            // here we get the parameters of the URL
            // HebCalParamsDTO result=new HebCalParamsDTO { CurrentDate = data.CurrentDate }// these are values that will overwrite
            //data is the parameter that you get from the MVS( it's a URL, and that you will send to BL)
            BL.WeatCalLogic bl = new();
            WeatherClass result = bl.WhatWeather(data.City);
            return result;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<WeatherController>/5
        // [HttpGet("{long}")]
        //public string Get(int id)
        //{
        //    BL.HebCalLogic bl = new BL.HebCalLogic();
        //    DateTime CurrentDate = DateTime.Now;
        //    string result = bl.isHoliday(CurrentDate);
        //    return result;
        //    //return new string[] { "value1", "value2" };
        //}

        // POST api/<WeatherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeatherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
