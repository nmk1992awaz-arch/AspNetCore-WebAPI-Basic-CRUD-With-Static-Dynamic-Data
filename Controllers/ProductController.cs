using Microsoft.AspNetCore.Mvc;
using Basic_CURD_Operation.Models;
namespace Basic_CURD_Operation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Products> _products = new List<Products>()
        {
            new Products(){Id=1,ProductName="Laptop",Price=50000,stock=10},
            new Products(){Id=2,ProductName="Mobile",Price=20000,stock=20},
            new Products(){Id=3,ProductName="Tablet",Price=30000,stock=15}
        };
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAll()
        {
            return Ok(_products);
        }
        [HttpGet("{id}")]
        public ActionResult<Products> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(Products product)
        {
            _products.Add(product);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Products product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.stock = product.stock;
            return Ok(existingProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return Ok(product);
        }
    }
}
