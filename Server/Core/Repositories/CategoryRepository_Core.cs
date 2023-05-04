using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.Agenda.Core.Models.Categories;

namespace Connect.Agenda.Core.Repositories
{

	public partial class CategoryRepository : ServiceLocator<ICategoryRepository, CategoryRepository>, ICategoryRepository
 {
        protected override Func<ICategoryRepository> GetFactory()
        {
            return () => new CategoryRepository();
        }
        public IEnumerable<Category> GetCategories(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Category>();
                return rep.Get(moduleId);
            }
        }
        public Category GetCategory(int moduleId, int categoryId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Category>();
                return rep.GetById(categoryId, moduleId);
            }
        }
        public Category AddCategory(Category category)
        {
            Requires.NotNull(category);
            Requires.PropertyNotNegative(category, "ModuleId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Category>();
                rep.Insert(category);
            }
            return category;
        }
        public void DeleteCategory(Category category)
        {
            Requires.NotNull(category);
            Requires.PropertyNotNegative(category, "CategoryId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Category>();
                rep.Delete(category);
            }
        }
        public void DeleteCategory(int moduleId, int categoryId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Category>();
                rep.Delete("WHERE ModuleId = @0 AND CategoryId = @1", moduleId, categoryId);
            }
        }
        public void UpdateCategory(Category category)
        {
            Requires.NotNull(category);
            Requires.PropertyNotNegative(category, "CategoryId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Category>();
                rep.Update(category);
            }
        } 
    }
    public partial interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(int moduleId);
        Category GetCategory(int moduleId, int categoryId);
        Category AddCategory(Category category);
        void DeleteCategory(Category category);
        void DeleteCategory(int moduleId, int categoryId);
        void UpdateCategory(Category category);
    }
}

