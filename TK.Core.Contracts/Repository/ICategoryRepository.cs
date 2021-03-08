using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Entites;

namespace TK.Core.Contracts.Repository
{
    public interface ICategoryRepository
    {
        Category GetCategory(string categoryName);
        void AddCategory(Category category);
    }
}
