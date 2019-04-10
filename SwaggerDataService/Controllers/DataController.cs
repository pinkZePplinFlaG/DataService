using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Service_Web_Role;
using ItemModelDataServiceRep;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        [HttpGet("GetItemById/id")]
        public ActionResult<InventoryItem> Get(long id)
        {
            return new Data_Service_Web_Role.Service1().GetItemById(id); 
        }

        [HttpGet]
        [Route("GetAllItems/")]
        public ActionResult<InventoryItem[]> GetAll()
        {
            return new Data_Service_Web_Role.Service1().GetAllItemsJson();
        }

        [HttpPost("SaveNewItem/")]
        public string Post([FromBody] InventoryItem value)
        {
            return new Data_Service_Web_Role.Service1().SaveNewItem(value);
        }

        [HttpDelete("DeleteItemById/{id}")]
        public string DeleteItem(long id)
        {
            return new Data_Service_Web_Role.Service1().DeleteItemById(id);
        }
    }
}
