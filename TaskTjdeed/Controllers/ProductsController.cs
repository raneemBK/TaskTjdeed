using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTjdeed.Models;
using TaskTjdeed.Services;

namespace TaskTjdeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productsService;
        public ProductsController(IProductsServices productsServices)
        {
            _productsService = productsServices;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _productsService.GetProducts();
                if (products == null)
                {
                    return NotFound();

                }
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductByID/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productsService.GetProductById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UdpateProduct")]
        public async Task<ActionResult<bool>> UpdateProduct(Product product)
        {
            try
            {
                var productToUpdate = await _productsService.UpdateProduct(product);
                if (productToUpdate) return Ok(true);
                return BadRequest(productToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("InsertProduct")]
        public async Task<ActionResult<Product>> InsertProduct(Product product)
        {
            try
            {
                var insertProduct = await _productsService.InsertProduct(product);
                if (insertProduct != null)
                {
                    return Ok(insertProduct);
                }
                return BadRequest(insertProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            try
            {
                var product = await _productsService.DeleteProduct(id);
                if (product) return Ok(product);
                return BadRequest(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
