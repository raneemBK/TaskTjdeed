using TaskTjdeed.Models;

namespace TaskTjdeed.Reposetories
{
    public interface IProductsRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProduct(Product product);
        public Task<Product> InsertProduct(Product product);
    }
}
