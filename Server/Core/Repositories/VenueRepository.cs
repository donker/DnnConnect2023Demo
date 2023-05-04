using Connect.Agenda.Core.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Connect.Agenda.Core.Repositories
{
  public partial class VenueRepository : ServiceLocator<IVenueRepository, VenueRepository>, IVenueRepository
  {
    public List<string> ListCities(int moduleId)
    {
      using (var context = DataContext.Instance())
      {
        var sql = @"SELECT DISTINCT
 v.City
FROM dbo.ConnectAgenda_Venues v
WHERE v.ModuleId=@0
ORDER BY v.City";
        return context.ExecuteQuery<VenueCity>(System.Data.CommandType.Text, sql, moduleId)
                .Select(v => v.City)
                .ToList();
      }
    }
  }
  public partial interface IVenueRepository
  {
    List<string> ListCities(int moduleId);
  }
}

