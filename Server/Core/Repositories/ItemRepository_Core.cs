using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.Agenda.Core.Models.Items;

namespace Connect.Agenda.Core.Repositories
{

	public partial class ItemRepository : ServiceLocator<IItemRepository, ItemRepository>, IItemRepository
 {
        protected override Func<IItemRepository> GetFactory()
        {
            return () => new ItemRepository();
        }
        public IEnumerable<Item> GetItems(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Item>();
                return rep.Get(moduleId);
            }
        }
        public Item GetItem(int moduleId, int itemId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Item>();
                return rep.GetById(itemId, moduleId);
            }
        }
        public ItemBase AddItem(ItemBase item, int userId)
        {
            Requires.NotNull(item);
            Requires.PropertyNotNegative(item, "ModuleId");
            item.CreatedByUserID = userId;
            item.CreatedOnDate = DateTime.Now;
            item.LastModifiedByUserID = userId;
            item.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ItemBase>();
                rep.Insert(item);
            }
            return item;
        }
        public void DeleteItem(ItemBase item)
        {
            Requires.NotNull(item);
            Requires.PropertyNotNegative(item, "ItemId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ItemBase>();
                rep.Delete(item);
            }
        }
        public void DeleteItem(int moduleId, int itemId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ItemBase>();
                rep.Delete("WHERE ModuleId = @0 AND ItemId = @1", moduleId, itemId);
            }
        }
        public void UpdateItem(ItemBase item, int userId)
        {
            Requires.NotNull(item);
            Requires.PropertyNotNegative(item, "ItemId");
            item.LastModifiedByUserID = userId;
            item.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ItemBase>();
                rep.Update(item);
            }
        } 
    }
    public partial interface IItemRepository
    {
        IEnumerable<Item> GetItems(int moduleId);
        Item GetItem(int moduleId, int itemId);
        ItemBase AddItem(ItemBase item, int userId);
        void DeleteItem(ItemBase item);
        void DeleteItem(int moduleId, int itemId);
        void UpdateItem(ItemBase item, int userId);
    }
}

