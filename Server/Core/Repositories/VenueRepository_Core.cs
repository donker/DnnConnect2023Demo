using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.Agenda.Core.Models.Venues;

namespace Connect.Agenda.Core.Repositories
{

	public partial class VenueRepository : ServiceLocator<IVenueRepository, VenueRepository>, IVenueRepository
 {
        protected override Func<IVenueRepository> GetFactory()
        {
            return () => new VenueRepository();
        }
        public IEnumerable<Venue> GetVenues(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Venue>();
                return rep.Get(moduleId);
            }
        }
        public Venue GetVenue(int moduleId, int venueId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Venue>();
                return rep.GetById(venueId, moduleId);
            }
        }
        public Venue AddVenue(Venue venue)
        {
            Requires.NotNull(venue);
            Requires.PropertyNotNegative(venue, "ModuleId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Venue>();
                rep.Insert(venue);
            }
            return venue;
        }
        public void DeleteVenue(Venue venue)
        {
            Requires.NotNull(venue);
            Requires.PropertyNotNegative(venue, "VenueId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Venue>();
                rep.Delete(venue);
            }
        }
        public void DeleteVenue(int moduleId, int venueId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Venue>();
                rep.Delete("WHERE ModuleId = @0 AND VenueId = @1", moduleId, venueId);
            }
        }
        public void UpdateVenue(Venue venue)
        {
            Requires.NotNull(venue);
            Requires.PropertyNotNegative(venue, "VenueId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Venue>();
                rep.Update(venue);
            }
        } 
    }
    public partial interface IVenueRepository
    {
        IEnumerable<Venue> GetVenues(int moduleId);
        Venue GetVenue(int moduleId, int venueId);
        Venue AddVenue(Venue venue);
        void DeleteVenue(Venue venue);
        void DeleteVenue(int moduleId, int venueId);
        void UpdateVenue(Venue venue);
    }
}

