using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.Agenda.Core.Models.Venues
{
    public partial class Venue : IPropertyAccess
    {

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "venueid": // Int
     return VenueId.ToString(strFormat, formatProvider);
    case "moduleid": // Int
     return ModuleId.ToString(strFormat, formatProvider);
    case "venuename": // NVarChar
     return PropertyAccess.FormatString(VenueName, strFormat);
    case "city": // NVarChar
     return PropertyAccess.FormatString(City, strFormat);
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

