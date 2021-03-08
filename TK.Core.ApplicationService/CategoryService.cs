using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Contracts.Repository;
using TK.Core.Contracts.Service;
using TK.Core.Entites;

namespace TK.Core.ApplicationService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }

        public Category GetCategory(string categoryName)
        {
            return categoryRepository.GetCategory(categoryName);
        }
    }
}
