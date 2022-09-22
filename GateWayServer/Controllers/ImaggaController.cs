using Microsoft.AspNetCore.Mvc;
using DP;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GateWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImaggaController : ControllerBase
    {
        // GET: api/<ImaggaController>
        [HttpGet]
        public bool Get([FromQuery]ImaggaParamsDTO data)
        {
            BL.ImaggaLogic bl = new BL.ImaggaLogic();

            //for try!
            //string ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKXuC1duqsa_7A2SC9HZn1szASPgvIJCdczQ&usqp=CAU";
           // string Name = "banana";

            bool result = bl.FittingImage(data);
            return result;
        }

        // GET api/<ImaggaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImaggaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ImaggaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImaggaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
