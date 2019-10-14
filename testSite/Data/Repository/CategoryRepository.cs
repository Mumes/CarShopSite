using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testSite.Data.Interfaces;
using testSite.Data.Models;

namespace testSite.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
