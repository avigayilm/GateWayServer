using GateWayServer.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            BL.HebCalLogic bl = new BL.HebCalLogic();
            DateTime CurrentDate = DateTime.Now;
            string result = bl.isHoliday(CurrentDate);
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
