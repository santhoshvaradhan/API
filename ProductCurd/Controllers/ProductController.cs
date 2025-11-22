using ProductAPI.Services;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using Microsoft.AspNetCore.Authorization;
using ProductAPI.DTO_Models;
namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="SuperAdmin,Admin,User")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllProducts")]
        public IEnumerable<Product> GetProductList()
        {
            return _productService.GetAll();
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(ProductDTO productDto)
        {
            var product = new Product { Name = productDto.Name,Price=productDto.Price,CategoryId=productDto.Category };
            _productService.Add(product);
            return Ok(new { isSucess = true, statusCode = 200, message = "Product Created Successfully" });
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteById(id);
            return Ok(new {isSucess=true,statusCode=200,message="Product Delete Successfully"});
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("UpdateProduct")]
        public ActionResult UpdateProduct(int id,[FromBody] Product product)
        {
            return Ok(new { isSucess = true, statusCode = 200, message = "Product Updated Successfully" });
        }

        [HttpGet("GetProduct/{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);
            return Ok(new { isSucess = true, statusCode = 200, Data = product });
        }
    }
}

