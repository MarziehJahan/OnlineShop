using System;
using System.Collections.Generic;
using System.Text;
using TK.Core.Entites;

namespace TK.Core.Contracts.Repository
{
    public interface IProductRepository
    {
        Product Get(int ProductId);

        (List<Product>, int Count) GetFilterProducts(string search, string category, int pageNumber, int PageSize);

        List<Product> GetChippestProduct();
        List<Product> GetNewstProduct();

        (List<Product>, int Count) GetCategoryProducts(string category);

        void AddProduct(Product product);
        List<Product> GetProducts();
    }

}

