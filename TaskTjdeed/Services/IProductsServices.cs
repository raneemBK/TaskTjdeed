using TaskTjdeed.Models;

namespace TaskTjdeed.Services
{
    public interface IProductsServices
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProduct(Product product);
        public Task<Product> InsertProduct(Product product);
    }
}
