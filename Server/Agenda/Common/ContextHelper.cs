using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Web.Api;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Connect.Agenda.Agenda.Common
{
  public class ContextHelper
  {
    public System.Web.UI.Page Page { get; set; }

    public virtual string ModulePath
    {
      get
      {
        return "~/DesktopModules/MVC/Connect/Agenda";
      }
    }

    public ContextHelper(Page page)
    {
      Page = page;
    }

    public void AddScript(string scriptName)
    {
      ClientResourceManager.RegisterScript(Page, string.Format(ModulePath + "/js/{0}", scriptName));
    }

    public void RegisterAjaxScript()
    {
      ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
      RegisterAjaxAntiForgery();
      var path = ServicesFramework.GetServiceFrameworkRoot();
      if (String.IsNullOrEmpty(path))
      {
        return;
      }

      JavaScript.RegisterClientReference(Page, ClientAPI.ClientNamespaceReferences.dnn);
      ClientAPI.RegisterClientVariable(Page, "sf_siteRoot", path, /*overwrite*/ true);
      ClientAPI.RegisterClientVariable(Page, "sf_tabId", DotNetNuke.Entities.Portals.PortalSettings.Current.ActiveTab.TabID.ToString(System.Globalization.CultureInfo.InvariantCulture), /*overwrite*/ true);

      string scriptPath;
      if (HttpContextSource.Current.IsDebuggingEnabled)
      {
        scriptPath = "~/js/Debug/dnn.servicesframework.js";
      }
      else
      {
        scriptPath = "~/js/dnn.servicesframework.js";
      }

      ClientResourceManager.RegisterScript(Page, scriptPath);
    }
    public void RegisterAjaxAntiForgery()
    {
      var ctl = Page.FindControl("ClientResourcesFormBottom");
      if (ctl != null)
      {
        var cc = ctl.Controls
            .Cast<Control>()
            .Where(l => l is LiteralControl)
            .Select(l => (LiteralControl)l)
            .Where(l => l.Text.IndexOf("__RequestVerificationToken") > 0)
            .FirstOrDefault();
        if (cc == null)
        {
          ctl.Controls.Add(new LiteralControl(System.Web.Helpers.AntiForgery.GetHtml().ToHtmlString()));
        }
      }
    }
  }
}
