using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI;

namespace Data_Service_Web_Role
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetItemByIdJson/{itemId}",
        Method ="GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        Item GetItemById(string itemId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetItemByCategoryJson/{categoryId}",
        Method ="GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        Item[] GetItemByCategory(string categoryId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/SaveNewItem/{itemCatId}/{isDraft}",
        Method ="POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        string SaveNewItem(string itemCatId, string isDraft);
    }


    //Data Types needed for app?
    //Item
    [DataContract]
    public class Item
    {
        string iD = "0";
        Category cat = null;
        bool isDraft = false;

        [DataMember]
        public bool IsDraft
        {
            get { return isDraft; }
            set { isDraft = value; }
        }

        [DataMember]
        public string ID
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
        string iD = "0";
        [DataMember]
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
