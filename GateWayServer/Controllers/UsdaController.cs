using DP;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsdaController : ControllerBase
    {
        // GET: api/<USDAController>
        [HttpGet]
        public Nutrient[] Get([FromQuery] string ingredients,string keyWord)// if no keyword than - is passed 
        {
            // here we get the parameters of the URL
            // HebCalParamsDTO result=new HebCalParamsDTO { CurrentDate = data.CurrentDate }// these are values that will overwrite
            //data is the parameter that you get from the MVS( it's a URL, and that you will send to BL)
            BL.UsdaLogic bl = new BL.UsdaLogic();
            DP.Nutrient[]nutrients = bl.NutrientsInfo(ingredients,keyWord);
            return nutrients;
            //return new string[] { "value1", "value2" 
        }

        // GET api/<USDAController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<USDAController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<USDAController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<USDAController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
