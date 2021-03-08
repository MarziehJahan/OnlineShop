using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TK.Core.Contracts.Repository;
using TK.Core.Entites;
using TK.Infrastruture.Sql;
using TK.Infrastruture.Sql.Config;

namespace TK.Infrastruture.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoContext context;

        public ProductRepository(DemoContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public Product Get(int ProductId)
        {
            return context.Products.Include(a => a.Medias)

                .First(a => a.ProductID == ProductId);
        }

        public (List<Product>, int Count) GetCategoryProducts(string category)
        {
            IQueryable<Product> query = context.Products.Include(a => a.Category)
                 .Where(a => a.Category.CategoryName == category).Include(a=>a.Medias);
            var lengthQuery = query.ToList().Count();
            return (query.ToList(), lengthQuery);
        }

        public List<Product> GetChippestProduct()
        {
            List<Product> result = new List<Product>();
            foreach (var category in context.Categories.ToList())
            {
                int minPrice = context.Products.Include(a => a.Category).Where(a => a.Category == category).Min(a => a.Price);
                result.Add(context.Products.Include(a => a.Medias).First(a => a.Price == minPrice));

            }
            return result;
        }

        public (List<Product>, int Count) GetFilterProducts(string search, string category, int pageNumber, int PageSize)
        {

            IQueryable<Product> query = context.Products.Include(a => a.Category).Include(a => a.Medias);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search) || a.Description.Contains(search));
            }
            if (category != "All")
            {
                query = query.Where(a => a.Category.CategoryName == category);

            }

            var lengthQuery = query.ToList().Count;

            return (query.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList(), lengthQuery);
        }



        public List<Product> GetNewstProduct()
        {
            return context.Products.Include(a => a.Medias)
                .OrderByDescending(a => a.InseretTime).ToList();
        }

        public List<Product> GetProducts()
        {
            return context
                .Products.Include(a=>a.Medias).OrderBy(a => a.Price).ToList();
        }
    }
}

