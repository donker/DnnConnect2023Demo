using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.Agenda.Core.Data;

namespace Connect.Agenda.Core.Models.Venues
{
    [TableName("ConnectAgenda_Venues")]
    [PrimaryKey("VenueId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class Venue     {

        #region .ctor
        public Venue()
        {
            VenueId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int VenueId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string VenueName { get; set; }
        [DataMember]
        public string City { get; set; }
        #endregion

        #region Methods
        public void ReadVenue(Venue venue)
        {
            if (venue.VenueId > -1)
                VenueId = venue.VenueId;

            if (venue.ModuleId > -1)
                ModuleId = venue.ModuleId;

            if (!String.IsNullOrEmpty(venue.VenueName))
                VenueName = venue.VenueName;

            if (!String.IsNullOrEmpty(venue.City))
                City = venue.City;

        }
        #endregion

    }
}



