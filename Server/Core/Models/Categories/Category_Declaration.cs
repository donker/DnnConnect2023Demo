using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.Agenda.Core.Data;

namespace Connect.Agenda.Core.Models.Categories
{
    [TableName("ConnectAgenda_Categories")]
    [PrimaryKey("CategoryId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class Category     {

        #region .ctor
        public Category()
        {
            CategoryId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        #endregion

        #region Methods
        public void ReadCategory(Category category)
        {
            if (category.CategoryId > -1)
                CategoryId = category.CategoryId;

            if (category.ModuleId > -1)
                ModuleId = category.ModuleId;

            if (!String.IsNullOrEmpty(category.CategoryName))
                CategoryName = category.CategoryName;

        }
        #endregion

    }
}



