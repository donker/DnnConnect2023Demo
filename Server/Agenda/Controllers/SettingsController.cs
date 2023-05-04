using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using Connect.Agenda.Agenda.Common;
using System.Web.Mvc;

namespace Connect.Agenda.Agenda.Controllers
{
    [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
    [DnnHandleError]
    public class SettingsController : AgendaMvcController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Settings()
        {
            return View(AgendaModuleContext.Settings);
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