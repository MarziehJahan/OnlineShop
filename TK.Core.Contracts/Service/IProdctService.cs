using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Entites;

namespace TK.Core.Contracts.Service
{
    public interface IProdctService
    {
        Product Get(int ProductId);
        (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize);
        (List<Product>, int Count) GetCategoryProducts(string category);

        List<Product> GetChippestProduct();
        List<Product> GetNewestProduct();
        void AddProduct(Product product);
        List<Product> GetProducts();

    }
}
