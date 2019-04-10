using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Service_Web_Role;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("GetItemById/id")]
        public ActionResult<Item> Get(int id)
        {
            return new Data_Service_Web_Role.Service1().GetItemById(id.ToString()); 
        }

        // GET api/values/5
        [HttpGet]
        [Route("GetAll/")]
        public ActionResult<Item[]> GetAll()
        {
            return new Data_Service_Web_Role.Service1().GetAllItemsJson();
        }

        // POST api/values
        [HttpPost("SaveNewItem/")]
        public string Post([FromBody] Item value)
        {
            return new Data_Service_Web_Role.Service1().SaveNewItem(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
