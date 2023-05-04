using System.Web.Mvc;
using Connect.Agenda.Agenda.Common;
using DotNetNuke.Web.Mvc.Framework.Controllers;

namespace Connect.Agenda.Agenda.Controllers
{
  public class HomeController : DnnController
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View(ModuleSettings.GetSettings(ActiveModule).View);
    }
  }
}
