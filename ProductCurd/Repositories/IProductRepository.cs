
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(int id,Product product);
        void DeleteById(int id);

        void CreateCategory(Category category);
        List<Category> GetAllCategories();


    }
}
