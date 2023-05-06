using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace Connect.Agenda.Agenda.Common
{
  public class AgendaMvcController : DnnController
  {

    private ContextHelper _AgendaModuleContext;
    public ContextHelper AgendaModuleContext
    {
      get { return _AgendaModuleContext ?? (_AgendaModuleContext = new ContextHelper(this)); }
    }

  }
}