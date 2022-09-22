using DP;
using GateWayServer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HebCalController : ControllerBase
    {
        // GET: api/<ValuesController>

        // we want to get the parameters from the url, becuase we are getting
        // a url request from the user.
        [HttpGet]
        public string Get([FromQuery]HebCalParamsDTO data)
        {
            // here we get the parameters of the URL
           // HebCalParamsDTO result=new HebCalParamsDTO { CurrentDate = data.CurrentDate }// these are values that will overwrite
           //data is the parameter that you get from the MVS( it's a URL, and that you will send to BL)
            BL.HebCalLogic bl= new BL.HebCalLogic();
            DateTime CurrentDate = DateTime.Now;
            string result= bl.isHoliday(CurrentDate);
            return result;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
