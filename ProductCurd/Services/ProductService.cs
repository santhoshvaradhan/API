using ProductAPI.Models;
using   ProductAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        public void Add(Product newProduct)
        {
            _productRepository.Add(newProduct);
        }

        public void Update(int id,Product updateProduct)
        {
            _productRepository.Update(id,updateProduct);
        }

        public void DeleteById(int id)
        {
            _productRepository.DeleteById(id);
        }

        public void CreateCategory(Category category)
        {
            _productRepository.CreateCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _productRepository.GetAllCategories();
        }
    }
}
