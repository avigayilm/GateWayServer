using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET: api/<WeatherController>
        [HttpGet]
        public string Get()
        {
            BL.WeatCalLogic bl = new();
            DateTime CurrentDate = DateTime.Now;
            string result = bl.WhatWeather();
            return result;
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            BL.HebCalLogic bl = new BL.HebCalLogic();
            DateTime CurrentDate = DateTime.Now;
            string result = bl.isHoliday(CurrentDate);
            return result;
            //return new string[] { "value1", "value2" };
        }

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
