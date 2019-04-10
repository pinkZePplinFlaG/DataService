using System;
using System.Runtime.Serialization;

namespace ItemModelDataServiceRep
{
    [DataContract]
    public class InventoryItem
    {
        private long ItemId;
        private long CompanyId;
        private DateTime RowAddedDateTime;
        private DateTime RowUpdatedDateTime;
        private DateTime StatusLastChanged;
        private long RowAddedByUserId;
        private ItemStatus Status;
        private decimal PurchasePrice;
        private decimal SellingPrice;
        //public Image PrimaryImage;
        //public Image[] AdditionalImages;
        private long CategoryId;
        private long SubCategoryId;
        private string[] Tags;
        private string ShortDescription;
        private ItemAttribute[] ItemAttributes;
        private ItemDescription Description;
        private Condition Condition;

        [DataMember]
        public long Item_Id
        {
            get { return ItemId; }
            set { ItemId = value; }
        }

        [DataMember]
        public long Company_Id
        {
            get { return CompanyId; }
            set { CompanyId = value; }
        }

        [DataMember]
        public DateTime Row_Added_Date_Time
        {
            get { return RowAddedDateTime; }
            set { RowAddedDateTime = value; }
        }

        [DataMember]
        public DateTime Row_Updated_Date_Time
        {
            get { return RowUpdatedDateTime; }
            set { RowUpdatedDateTime = value; }
        }

        [DataMember]
        public DateTime Status_Last_Changed
        {
            get { return StatusLastChanged; }
            set { StatusLastChanged = value; }
        }

        [DataMember]
        public long Row_Added_By_User_Id
        {
            get { return RowAddedByUserId; }
            set { RowAddedByUserId = value; }
        }

        [DataMember]
        public ItemStatus Status_
        {
            get { return Status; }
            set { Status = value; }
        }

        [DataMember]
        public decimal Purchase_Price
        {
            get { return PurchasePrice; }
            set { PurchasePrice = value; }
        }

        [DataMember]
        public decimal Selling_Price
        {
            get { return SellingPrice; }
            set { SellingPrice = value; }
        }

        [DataMember]
        public long Category_Id
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        }

        [DataMember]
        public long Sub_Category_Id
        {
            get { return SubCategoryId; }
            set {SubCategoryId = value; }
        }

        [DataMember]
        public string[] Tags_
        {
            get { return Tags; }
            set { Tags = value; }
        }

        [DataMember]
        public string Short_Description
        {
            get { return ShortDescription; }
            set { ShortDescription = value; }
        }

        [DataMember]
        public ItemAttribute[] Item_Attributes
        {
            get { return ItemAttributes; }
            set { ItemAttributes = value; }
        }

        [DataMember]
        public ItemDescription Description_
        {
            get { return Description; }
            set { Description = value; }
        }

        [DataMember]
        public Condition Condition_
        {
            get { return Condition; }
            set { Condition = value; }
        }
    }

    [DataContract]
    public class ItemStatus
    {
        private long StatusId;
        private string StatusDescription;
        [DataMember]
        public long StatusId_
        {
            get { return StatusId; }
            set { StatusId = value; }
        }
        [DataMember]
        public string StatusDescription_
        {
            get { return StatusDescription; }
            set { StatusDescription = value; }
        }
    }

    [DataContract]
    public class ItemAttribute
    {
        private long AttributeId;
        private long CategoryAttributeId;
        private bool Required;
        private int ListOrder;
        private string AttributeDescription;
        private string AttributeValueType;
        private dynamic AttributeValue;

        [DataMember]
        public long AttributeId_
        {
            get {return AttributeId; }
            set {AttributeId = value; }
        } //uniquely identifies this attribute for this item


        [DataMember]
        public long Category_Attribute_Id
        {
            get { return CategoryAttributeId; }
            set { CategoryAttributeId = value; }
        } //identifies the category attribute that goes with this -> need to use this to map to Ebay/Etsy item attributes

        [DataMember]
        public bool Required_
        {
            get { return Required; }
            set { Required = value; }
        }

        [DataMember]
        public int ListOrder_
        {
            get { return ListOrder; }
            set { ListOrder = value; }
        } //determines the order by which the user is prompted for this value in the app

        [DataMember]
        public string AttributeDescription_
        {
            get { return AttributeDescription; }
            set { AttributeDescription = value; }
        } //used to prompt the user, ie Brand, Style, etc

        [DataMember]
        public string AttributeValueType_
        {
            get { return AttributeValueType; }
            set { AttributeValueType = value; }
        }

        [DataMember]
        public dynamic AttributeValue_
        {
            get { return AttributeValue; }
            set { AttributeValue = value; }
        }
    }

    [DataContract]
    public class ItemDescription
    {
        private long DescriptionId;
        private string ListingTitleDescription;
        private string MainDescription;
        //private Disclaimer[] Disclaimers;
        //private Note[] AdditionalNotes;
        //private ClothingMeasurement[] Measurements;
        //p ShippingDetails ShippingDetails;
        [DataMember]
        public long Description_Id
        {
            get { return DescriptionId; }
            set { DescriptionId = value; }
        } //uniquely identifies this attribute for this item

        [DataMember]
        public string Listing_Title_Description
        {
            get { return ListingTitleDescription; }
            set { ListingTitleDescription = value; }
        } //identifies the category attribute that goes with this -> need to use this to map to Ebay/Etsy item attributes

        [DataMember]
        public string Main_Description
        {
            get { return MainDescription; }
            set { MainDescription = value; }
        }
    }

    [DataContract]
    public class Condition
    {
        private long ConditionId;
        private string ConditionDescription;
        [DataMember]
        public long ConditionId_
        {
            get {return ConditionId; }
            set {ConditionId = value; }
        }

        [DataMember]
        public string ConditionDescription_
        {
            get {return ConditionDescription; }
            set {ConditionDescription = value; }
        }
    }
}
