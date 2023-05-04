using DotNetNuke.Web.Api;

namespace Connect.Agenda.Agenda.Common
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("Connect/Agenda", "AgendaMap1", "{controller}/{action}", null, null, new[] { "Connect.Agenda.Agenda.Api" });
            mapRouteManager.MapHttpRoute("Connect/Agenda", "AgendaMap2", "{controller}/{action}/{id}", null, new { id = "-?\\d+" }, new[] { "Connect.Agenda.Agenda.Api" });
        }
    }
}