using Connect.Agenda.Agenda.Common;
using Connect.Agenda.Core.Repositories;
using System.Web.Mvc;

namespace Connect.Agenda.Agenda.Controllers
{
  public class ItemsController : AgendaMvcController
  {
    [HttpGet]
    public ActionResult Index(int id)
    {
      var item = ItemRepository.Instance.GetItem(ActiveModule.ModuleID, id);
      return View(item);
    }
  }
}
