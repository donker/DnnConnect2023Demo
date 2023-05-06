using Connect.Agenda.Agenda.Common;
using Connect.Agenda.Core.Models.Items;
using Connect.Agenda.Core.Repositories;
using DotNetNuke.Web.Api;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Connect.Agenda.Agenda.Api
{
  public class ItemController : AgendaApiController
  {
    [HttpGet]
    [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
    public HttpResponseMessage List(int category, string city, string searchText, string sortField, string sortOrder, int pageSize, int pageIndex)
    {
      return Request.CreateResponse(HttpStatusCode.OK, ItemRepository.Instance.List(ActiveModule.ModuleID, DateTime.Now, category, city, searchText, sortField, sortOrder, pageSize, pageIndex).Serialize());
    }

    [HttpPost]
    [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
    public HttpResponseMessage Update(Item data)
    {
      if (data.ItemId < 0)
      {
        data.ModuleId = ActiveModule.ModuleID;
        ItemRepository.Instance.AddItem(data.GetItemBase(), UserInfo.UserID);
      }
      else
      {
        var existing = ItemRepository.Instance.GetItem(ActiveModule.ModuleID, data.ItemId);
        if (existing != null)
        {
          existing.Title = data.Title;
          existing.Description = data.Description;
          existing.Category = data.Category;
          existing.Venue = data.Venue;
          ItemRepository.Instance.UpdateItem(existing.GetItemBase(), UserInfo.UserID);
        }
      }
      return Request.CreateResponse(HttpStatusCode.OK, true);
    }
  }
}
