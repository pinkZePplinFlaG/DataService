using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.IO;
using ItemModelDataServiceRep;

namespace Data_Service_Web_Role
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static Dictionary<long, InventoryItem> ITByItemId = new Dictionary<long, InventoryItem>();//"Item Table keyed by ItemId"
        static Dictionary<long, ArrayList> ITByCatId = new Dictionary<long, ArrayList>();//"Item Table keyed by CatId"

        public string DeleteItemById(long itemId)
        {
            ITByItemId.Remove(itemId);
            //this code will be used when database is available
            /*try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //replace these fields with itemDB credentials
                builder.DataSource = "";//ex: "<server>.database.windows.net";
                builder.UserID = "";//ex: "<username>";
                builder.Password = "";//ex: "<password>";
                builder.InitialCatalog = "";//ex: "<database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();//open the connection to the database
                    StringBuilder sb = new StringBuilder();
                    //example for how to build query:
                    //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }*/   
            return "item deleted successfully";
        }

        public InventoryItem[] GetAllItemsJson()
        {
            return ITByItemId.Values.ToArray();
        }

        public string SaveNewItem(InventoryItem jsonItem)
        {
            ITByItemId.Add(jsonItem.Item_Id, jsonItem);
            ArrayList test;
            if (ITByCatId.TryGetValue(jsonItem.Category_Id, out test))
            {
                test.Add(jsonItem);
            }
            else
            {
                ArrayList newCatList = new ArrayList();
                newCatList.Add(jsonItem);
                ITByCatId.Add(jsonItem.Category_Id, newCatList);
            }

            return "item saved successfully";
        }

        public InventoryItem GetItemById(long itemId)
        {
            return ITByItemId[itemId];
            //this code will be used when database is available
            /*try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //replace these fields with itemDB credentials
                builder.DataSource = "";//ex: "<server>.database.windows.net";
                builder.UserID = "";//ex: "<username>";
                builder.Password = "";//ex: "<password>";
                builder.InitialCatalog = "";//ex: "<database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();//open the connection to the database
                    StringBuilder sb = new StringBuilder();
                    //example for how to build query:
                    //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }*/
        }

        public InventoryItem[] GetItemByCategory(long categoryId)
        {
            return (InventoryItem[])ITByCatId[categoryId].ToArray(typeof(InventoryItem));
            //this code will be used when database is available
            /*try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //replace these fields with itemDB credentials
                builder.DataSource = "";//ex: "<server>.database.windows.net";
                builder.UserID = "";//ex: "<username>";
                builder.Password = "";//ex: "<password>";
                builder.InitialCatalog = "";//ex: "<database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();//open the connection to the database
                    StringBuilder sb = new StringBuilder();
                    //example for how to build query:
                    //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }*/
        }
    }
}
