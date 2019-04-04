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

namespace Data_Service_Web_Role
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static ArrayList testItems = new ArrayList();
        static Category[] testCategories = new Category[3];
        static private bool initialized = false;
        static private int nextId = -1;
        private void InitializeTestItems()
        {
            initialized = true;
            testCategories[0] = new Category();
            testCategories[0].ID = "hat";
            testCategories[1] = new Category();
            testCategories[1].ID = "shirt";
            testCategories[2] = new Category();
            testCategories[2].ID = "shoes";
            for (int i = 0; i < 10; i++)
            {
                testItems.Add(new Item());
                ((Item)testItems[i]).ID = GenerateItemId();
                ((Item)testItems[i]).Cat = testCategories[i % 3];
            }
        }

        private int GenerateItemId()
        {
            nextId++;
            return nextId;
        }

        public string SaveNewItem(Item jsonItem)
        {
            if (!initialized)
                InitializeTestItems();
            jsonItem.ID = GenerateItemId();
            testItems.Add(jsonItem);
            return "item saved successfully";
        }

        public Item GetItemById(string itemId)
        {
            if (!initialized)
                InitializeTestItems();
            for (int i = 0; i < testItems.Count; i++)
            {
                if ((((Item)testItems[i]).ID.ToString()).Equals(itemId))
                {
                    return (Item)testItems[i];
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
            return new Item();//fill this item with data from ItemDB
        }

        public Item[] GetItemByCategory(string categoryId)
        {
            ArrayList returnItems = new ArrayList();
            if (!initialized)
                InitializeTestItems();
            for (int i = 0; i < testItems.Count; i++)
            {
                if (((Item)testItems[i]).Cat.ID.Equals(categoryId))
                {
                    returnItems.Add(testItems[i]);
                }
            }
            return (Item[]) returnItems.ToArray(typeof(Item));
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
