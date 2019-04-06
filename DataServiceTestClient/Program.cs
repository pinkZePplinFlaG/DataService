using Data_Service_Web_Role;
using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace DataServiceTestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Item item = new Item();
            item.Cat = new Category();
            item.ID = 0;
            item.IsDraft = true;
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string strUri = "http://localhost:52039/Service1.svc/SaveNewItem";
            Uri uri = new Uri(strUri);
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string serOut = jsonSerializer.Serialize(item);

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(serOut);
            }

            WebResponse responce = request.GetResponse();
            Stream reader = responce.GetResponseStream();

            StreamReader sReader = new StreamReader(reader);
            string outResult = sReader.ReadToEnd();
            Console.Write(outResult);
            sReader.Close();
        }
    }
}
