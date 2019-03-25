using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Data_Service_Web_Role
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Item GetItemById(int itemId);

        [OperationContract]
        Item GetItemByCategory(int categoryId);
    }


    //Data Types needed for app?
    //Item
    [DataContract]
    public class Item
    {
        int iD = 0;
        Category cat = null;

        [DataMember]
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        [DataMember]
        public Category Cat
        {
            get { return cat; }
            set { cat = value; }
        }
    }

    [DataContract]
    public class Category
    {
        int iD = 0;
        [DataMember]
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
