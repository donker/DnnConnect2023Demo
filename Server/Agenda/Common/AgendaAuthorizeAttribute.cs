using DotNetNuke.Common;
using DotNetNuke.Entities.Users;
using DotNetNuke.Instrumentation;
using DotNetNuke.Web.Api;

namespace Connect.Agenda.Agenda.Common
{
  public enum SecurityAccessLevel
  {
    Anonymous = 0,
    Authenticated = 1,
    View = 2,
    Edit = 3,
    Manage = 4,
    Admin = 5,
    Host = 6
  }

  public class AgendaAuthorizeAttribute : AuthorizeAttributeBase, IOverrideDefaultAuthLevel
  {
    private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(AgendaAuthorizeAttribute));
    public SecurityAccessLevel SecurityLevel { get; set; }
    public UserInfo User { get; set; }

    public AgendaAuthorizeAttribute()
    {
      SecurityLevel = SecurityAccessLevel.Admin;
    }

    public AgendaAuthorizeAttribute(SecurityAccessLevel accessLevel)
    {
      SecurityLevel = accessLevel;
    }

    public override bool IsAuthorized(AuthFilterContext context)
    {
      Logger.Trace("IsAuthorized");
      if (SecurityLevel == SecurityAccessLevel.Anonymous)
      {
        Logger.Trace("Anonymous");
        return true;
      }
      User = HttpContextSource.Current.Request.IsAuthenticated ? UserController.Instance.GetCurrentUserInfo() : new UserInfo();
      Logger.Trace("UserId " + User.UserID.ToString());
      var security = new ContextSecurity(context.ActionContext.Request.FindModuleInfo(), UserController.Instance.GetCurrentUserInfo());
      Logger.Trace(security.ToString());
      switch (SecurityLevel)
      {
        case SecurityAccessLevel.Authenticated:
          return User.UserID != -1;
        case SecurityAccessLevel.Host:
          return User.IsSuperUser;
        case SecurityAccessLevel.Admin:
          return User.IsAdmin;
        case SecurityAccessLevel.Manage:
          return security.CanManage;
        case SecurityAccessLevel.Edit:
          return security.CanEdit;
        case SecurityAccessLevel.View:
          return security.CanView;
      }
      return false;
    }
  }
}