using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.Agenda.Core.Models.Items
{
    public partial class ItemBase : IPropertyAccess
    {

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "itemid": // Int
     return ItemId.ToString(strFormat, formatProvider);
    case "moduleid": // Int
     return ModuleId.ToString(strFormat, formatProvider);
    case "datefrom": // DateTime
     if (DateFrom == null)
     {
         return "";
     };
     return ((DateTime)DateFrom).ToString(strFormat, formatProvider);
    case "dateto": // DateTime
     if (DateTo == null)
     {
         return "";
     };
     return ((DateTime)DateTo).ToString(strFormat, formatProvider);
    case "title": // NVarChar
     return PropertyAccess.FormatString(Title, strFormat);
    case "description": // NVarCharMax
     if (Description == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Description, strFormat);
    case "venue": // Int
     return Venue.ToString(strFormat, formatProvider);
    case "category": // Int
     return Category.ToString(strFormat, formatProvider);
                default:
                    propertyNotFound = true;
                    break;
            }

            return Null.NullString;
        }

        [IgnoreColumn()]
        public CacheLevel Cacheability
        {
            get { return CacheLevel.fullyCacheable; }
        }
        #endregion

    }
}

