using Data_Service_Web_Role;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataServiceTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.Serialize(new Item());
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:52039/Service1.svc/SaveNewItem/");

            request.Method = "POST";
            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
