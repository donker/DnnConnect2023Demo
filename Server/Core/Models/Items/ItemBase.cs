using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.Agenda.Core.Data;

namespace Connect.Agenda.Core.Models.Items
{
    [TableName("ConnectAgenda_Items")]
    [PrimaryKey("ItemId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class ItemBase  : AuditableEntity 
    {

        #region .ctor
        public ItemBase()
        {
            ItemId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Venue { get; set; }
        [DataMember]
        public int Category { get; set; }
        #endregion

        #region Methods
        public void ReadItemBase(ItemBase item)
        {
            if (item.ItemId > -1)
                ItemId = item.ItemId;

            if (item.ModuleId > -1)
                ModuleId = item.ModuleId;

            if (item.DateFrom != null)
            DateFrom = item.DateFrom;

            if (item.DateTo != null)
            DateTo = item.DateTo;

            if (!String.IsNullOrEmpty(item.Title))
                Title = item.Title;

            if (!String.IsNullOrEmpty(item.Description))
                Description = item.Description;

            if (item.Venue > -1)
                Venue = item.Venue;

            if (item.Category > -1)
                Category = item.Category;

        }
        #endregion

    }
}



