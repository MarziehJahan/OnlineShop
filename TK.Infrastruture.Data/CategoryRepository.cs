using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TK.Core.Contracts.Repository;
using TK.Core.Entites;
using TK.Infrastruture.Sql;

namespace TK.Infrastruture.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DemoContext context;

        public CategoryRepository(DemoContext context)
        {
            this.context = context;
        }
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public Category GetCategory(string categoryName)
        {
            return context.Categories.SingleOrDefault(a => a.CategoryName == categoryName);
        }
    }
}
