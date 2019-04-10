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
        static ArrayList testItems = new ArrayList();//"database"

        public string DeleteItemById(long itemId)
        {
            for (int i = 0; i < testItems.Count; i++)
            {
                if (((InventoryItem)testItems[i]).Item_Id == itemId)
                {
                    testItems.RemoveAt(i);
                }
            }
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
            return (InventoryItem[])testItems.ToArray(typeof(InventoryItem));
        }

        public string SaveNewItem(InventoryItem jsonItem)
        {
            testItems.Add(jsonItem);
            return "item saved successfully";
        }

        public InventoryItem GetItemById(long itemId)
        {
            for (int i = 0; i < testItems.Count; i++)
            {
                if (((InventoryItem)testItems[i]).Item_Id == itemId)
                {
                    return (InventoryItem)testItems[i];
                }
            }
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
            return new InventoryItem();//fill this item with data from ItemDB
        }

        public InventoryItem[] GetItemByCategory(long categoryId)
        {
            ArrayList returnItems = new ArrayList();
            for (int i = 0; i < testItems.Count; i++)
            {
                if (((InventoryItem)testItems[i]).Category_Id == categoryId)
                {
                    returnItems.Add(testItems[i]);
                }
            }
            return (InventoryItem[]) returnItems.ToArray(typeof(InventoryItem));
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
