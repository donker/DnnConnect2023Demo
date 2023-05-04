using System.Web.Mvc;
using Connect.Agenda.Agenda.Common;

namespace Connect.Agenda.Agenda.Controllers
{
    public class HomeController : AgendaMvcController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(AgendaModuleContext.Settings.View);
        }
    }
}
