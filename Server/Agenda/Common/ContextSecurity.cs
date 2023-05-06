using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security;
using DotNetNuke.Security.Permissions;

namespace Connect.Agenda.Agenda.Common
{
  public class ContextSecurity
  {
    public bool CanView { get; set; }
    public bool CanEdit { get; set; }
    public bool CanManage { get; set; }
    public bool IsAdmin { get; set; }
    private UserInfo user { get; set; }
    public int UserId
    {
      get
      {
        return user.UserID;
      }
    }

    public ContextSecurity(ModuleInfo objModule, UserInfo user)
    {
      this.user = user;
      if (user.IsSuperUser)
      {
        CanView = CanEdit = CanManage = IsAdmin = true;
      }
      else
      {
        IsAdmin = PortalSecurity.IsInRole(PortalSettings.Current.AdministratorRoleName);
        if (IsAdmin)
        {
          CanView = CanEdit = CanManage = true;
        }
        else
        {
          CanView = ModulePermissionController.CanViewModule(objModule);
          CanEdit = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, "EDIT");
          CanManage = ModulePermissionController.HasModulePermission(objModule.ModulePermissions, "MANAGE");
        }
      }
    }
  }
}