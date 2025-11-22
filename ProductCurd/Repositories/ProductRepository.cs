using ProductAPI.Data;
using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;

        }

        public List<Product> GetAll()
        {
            return _productDbContext.Products.IgnoreAutoIncludes().Include(c=>c.Category).ToList();
        }
        public Product GetById(int id)
        {
            return _productDbContext.Products.Where(c=>c.Id==id).IgnoreAutoIncludes().Include(c=>c.Category).FirstOrDefault();
            _productDbContext.SaveChanges();
        }
        public void Add(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
        }
        public void Update(int id, Product Updateproduct)
        {
            var product = _productDbContext.Products.Find(id);
            product.Name = Updateproduct.Name;
            product.Price = Updateproduct.Price;
            _productDbContext.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var product = _productDbContext.Products.Find(id);
            _productDbContext.Products.Remove(product);
            _productDbContext.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            _productDbContext.Category.Add(category);
            _productDbContext.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _productDbContext.Category.Include(c=>c.Products).ToList();
        }
    }
}
