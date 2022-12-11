using Business.Abstract;
using Business.Constans;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("productList")]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetAllProduct();
            if (products != null)
                return Ok(new { status = 200, message = products });
            return BadRequest();

        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct(Product product)
        {
            var addProduct = _productService.AddProduct(product);
            if (addProduct.Success)
                return Ok(new { status = 200, message = addProduct });
            return BadRequest(new { status = 400, message = addProduct });

        }

        [HttpGet("getById")]
        public IActionResult GetById(int Id)
        {
            var getProduct = _productService.GetById(Id);
            if (getProduct.Success)
                return Ok(new { status = 200, message = getProduct });
            return BadRequest(new { status = 400, message = getProduct });
        }

    }
}
