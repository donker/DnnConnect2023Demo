using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using Connect.Agenda.Agenda.Common;
using System.Web.Mvc;
using DotNetNuke.Web.Mvc.Framework.Controllers;

namespace Connect.Agenda.Agenda.Controllers
{
  [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  [DnnHandleError]
  public class SettingsController : DnnController
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult Settings()
    {
      return View(ModuleSettings.GetSettings(ActiveModule));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="supportsTokens"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateInput(false)]
    [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
    public ActionResult Settings(ModuleSettings settings)
    {
      settings.SaveSettings(ModuleContext.Configuration);
      return RedirectToDefaultRoute();
    }
  }
}