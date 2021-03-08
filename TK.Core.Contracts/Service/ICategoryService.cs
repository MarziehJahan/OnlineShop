using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Entites;

namespace TK.Core.Contracts.Service
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        Category GetCategory(string categoryName);
    }
}
