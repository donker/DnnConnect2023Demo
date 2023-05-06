using DotNetNuke.Instrumentation;
using DotNetNuke.Web.Api;
using System.Net;
using System.Net.Http;

namespace Connect.Agenda.Agenda.Common
{
  public class AgendaApiController : DnnApiController
  {
    public static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(DnnApiController));

    private ContextHelper _AgendaModuleContext;
    public ContextHelper AgendaModuleContext
    {
      get { return _AgendaModuleContext ?? (_AgendaModuleContext = new ContextHelper(this)); }
    }

    public HttpResponseMessage ServiceError(string message)
    {
      return Request.CreateResponse(HttpStatusCode.InternalServerError, message);
    }

    public HttpResponseMessage AccessViolation(string message)
    {
      return Request.CreateResponse(HttpStatusCode.Unauthorized, message);
    }

  }
}