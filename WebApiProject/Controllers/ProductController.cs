using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Services;

namespace WebApiProject.Controllers
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

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll(int top = 0)
        {
            var products = _productService.GetProducts(top);
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var item = _productService.GetProductById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            var addedItem = _productService.Add(product);
            if (addedItem.Id == 0 || addedItem == null) return BadRequest();
            return Ok(addedItem);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            var item = _productService.Update(product);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = _productService.Delete(id);
            if (!item) return BadRequest();
            return Ok(item);
        }
    }
}
