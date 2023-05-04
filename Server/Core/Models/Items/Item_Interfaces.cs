using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.Agenda.Core.Models.Items
{

 [Serializable(), XmlRoot("Item")]
 public partial class Item
 {

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "venuename": // NVarChar
     return PropertyAccess.FormatString(VenueName, strFormat);
    case "city": // NVarChar
     return PropertyAccess.FormatString(City, strFormat);
    case "categoryname": // NVarChar
     return PropertyAccess.FormatString(CategoryName, strFormat);
    case "createdbyuser": // NVarChar
     if (CreatedByUser == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(CreatedByUser, strFormat);
    case "modifiedbyuser": // NVarChar
     if (ModifiedByUser == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(ModifiedByUser, strFormat);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

