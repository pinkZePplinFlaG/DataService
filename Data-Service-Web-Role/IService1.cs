using ItemModelDataServiceRep;
using System;
using System.Collections.Generic;
using System.IO;
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
        Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        InventoryItem GetItemById(long itemId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetAllItemsJson/",
        Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        InventoryItem[] GetAllItemsJson();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetItemByCategoryJson/{categoryId}",
        Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        InventoryItem[] GetItemByCategory(long categoryId);

        [OperationContract]
        [WebInvoke(Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        string SaveNewItem(InventoryItem jsonItem);

        [OperationContract]
        [WebInvoke(UriTemplate = "/DeleteItemById/{itemId}",
        Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        string DeleteItemById(long itemId);
    }
}