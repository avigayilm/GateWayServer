using DP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLController : ControllerBase
    {
        [HttpGet]
      //  [HttpGet("{Weather}/{Holiday}/{LastCategory}")]
        public string Get([FromQuery] BigMLDTO data)
        {
           
            //data is the parameter that you get from the MVS( it's a URL, and that you will send to BL)
            BL.MLlogic bl = new();
            string prediction = bl.Prediction(data.Weather, data.Holiday, data.LastCategory);
           // WeatherClass result = bl.WhatWeather(data.City);
            return prediction;
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
