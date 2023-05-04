using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.Agenda.Core.Models.Items
{

    [TableName("vw_ConnectAgenda_Items")]
    [PrimaryKey("ItemId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]                
    public partial class Item  : ItemBase 
    {

        #region .ctor
        public Item()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public string VenueName { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string CreatedByUser { get; set; }
        [DataMember]
        public string ModifiedByUser { get; set; }
        #endregion

        #region Methods
        public ItemBase GetItemBase()
        {
            ItemBase res = new ItemBase();
             res.ItemId = ItemId;
             res.ModuleId = ModuleId;
             res.DateFrom = DateFrom;
             res.DateTo = DateTo;
             res.Title = Title;
             res.Description = Description;
             res.Venue = Venue;
             res.Category = Category;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        public Item Clone()
        {
            Item res = new Item();
            res.ItemId = ItemId;
            res.ModuleId = ModuleId;
            res.DateFrom = DateFrom;
            res.DateTo = DateTo;
            res.Title = Title;
            res.Description = Description;
            res.Venue = Venue;
            res.Category = Category;
            res.VenueName = VenueName;
            res.City = City;
            res.CategoryName = CategoryName;
            res.CreatedByUser = CreatedByUser;
            res.ModifiedByUser = ModifiedByUser;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        #endregion

    }
}
