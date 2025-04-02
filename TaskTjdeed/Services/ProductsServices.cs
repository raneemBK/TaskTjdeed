using TaskTjdeed.Models;
using TaskTjdeed.Reposetories;

namespace TaskTjdeed.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _repository;
        public ProductsServices(IProductsRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> DeleteProduct(int id)
        {
            return _repository.DeleteProduct(id);
        }

        public Task<Product> GetProductById(int id)
        {
            return (_repository.GetProductById(id));
        }

        public Task<List<Product>> GetProducts()
        {
            return _repository.GetProducts();
        }

        public Task<Product> InsertProduct(Product product)
        {
            return _repository.InsertProduct(product);
        }

        public Task<bool> UpdateProduct(Product product)
        {
            return _repository.UpdateProduct(product);
        }
    }
}
