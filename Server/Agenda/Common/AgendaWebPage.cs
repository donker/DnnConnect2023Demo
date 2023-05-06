using System.Web.Mvc;
using DotNetNuke.Web.Mvc.Helpers;
using DotNetNuke.Web.Mvc.Framework;

namespace Connect.Agenda.Agenda.Common
{
  public abstract class AgendaWebPage : DnnWebViewPage
  {

    public ContextHelper AgendaModuleContext { get; set; }

    public override void InitHelpers()
    {
      Ajax = new AjaxHelper<object>(ViewContext, this);
      Html = new DnnHtmlHelper<object>(ViewContext, this);
      Url = new DnnUrlHelper(ViewContext);
      Dnn = new DnnHelper<object>(ViewContext, this);
    }

    public string SerializedResources()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(DotNetNuke.Services.Localization.LocalizationProvider.Instance.GetCompiledResourceFile(Dnn.PortalSettings, "/DesktopModules/MVC/Connect/Agenda/App_LocalResources/ClientResources.resx",
              System.Threading.Thread.CurrentThread.CurrentCulture.Name));
    }
  }
}