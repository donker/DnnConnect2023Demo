using Connect.Agenda.Core.Models.Items;
using DotNetNuke.Collections;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System;
using System.Collections.Generic;

namespace Connect.Agenda.Core.Repositories
{
  public partial class ItemRepository : ServiceLocator<IItemRepository, ItemRepository>, IItemRepository
  {
    public IPagedList<Item> List(int moduleId, DateTime start, int category, string city, string searchText, string sortField, string sortOrder, int pageSize, int pageIndex)
    {
      using (var context = DataContext.Instance())
      {
        var repo = context.GetRepository<Item>();
        var wheres = new List<string>
        {
          $"(ModuleId={moduleId})",
          $"(DateTo>='{start.ToString("yyyy-MM-dd HH:mm")}')"
        };
        if (category > -1)
        {
          wheres.Add($"(Category={category})");
        }
        if (!string.IsNullOrEmpty(city))
        {
          wheres.Add($"(City='{city}')");
        }
        if (!string.IsNullOrEmpty(searchText))
        {
          wheres.Add(string.Format("(Title LIKE '%{0}%' OR Description LIKE '%{0}%')", searchText));
        }
        var sql = string.Format("WHERE {0} ORDER BY {1} {2}", string.Join(" AND ", wheres), sortField, sortOrder);
        return repo.Find(pageIndex, pageSize, sql);
      }
    }
  }
  public partial interface IItemRepository
  {
    IPagedList<Item> List(int moduleId, DateTime start, int category, string city, string searchText, string sortField, string sortOrder, int pageSize, int pageIndex);
  }
}

