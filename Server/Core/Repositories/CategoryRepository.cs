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
    }
    public partial interface ICategoryRepository
    {
    }
}

