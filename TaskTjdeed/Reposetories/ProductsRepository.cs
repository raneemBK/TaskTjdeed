using Microsoft.EntityFrameworkCore;
using TaskTjdeed.Models;

namespace TaskTjdeed.Reposetories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly TaskTjdeedContext _context;
        public ProductsRepository(TaskTjdeedContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> InsertProduct(Product product)
        {
            try
            {
                if (product == null) return null;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Description = product.Description;
                    existingProduct.StockQuantity = product.StockQuantity;

                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
