using Api.Entities;

namespace Api.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductByIdAsync(Guid productId);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(Guid productId);
}