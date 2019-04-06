using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Swagger;

[assembly: OwinStartup(typeof(DataServiceWebApi.Startup1))]

namespace DataServiceWebApi
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
