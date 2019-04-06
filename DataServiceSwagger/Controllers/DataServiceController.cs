using Data_Service_Web_Role;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataServiceSwagger.Controllers
{
    public class DataServiceController : ApiController
    {
        // GET: api/DataService
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DataService/5
        [SwaggerOperation("GetItemById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public Item Get(int id)
        {
            Data_Service_Web_Role.IService1 pxy = new Data_Service_Web_Role.Service1();
            return pxy.GetItemById(id.ToString());
        }

        // POST: api/DataService
        public string Post([FromBody]Item value)
        {
            Data_Service_Web_Role.IService1 pxy = new Data_Service_Web_Role.Service1();
            return pxy.SaveNewItem(value);
        }

        // PUT: api/DataService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DataService/5
        public void Delete(int id)
        {
        }
    }
}
