using Api.Data;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class ProductRepository : IProductRepository
{
    private DataContext _dataContext { get; set; }

    public ProductRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _dataContext.Products.Include(product => product.Tags).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(Guid productId)
    {
        return await _dataContext.Products.Include(note => note.Tags).SingleOrDefaultAsync(x => x.Id == productId);
    }
    
    public async Task<bool> CreateProductAsync(Product product)
    {
        await _dataContext.Products.AddAsync(product);
        var created = await _dataContext.SaveChangesAsync();
        return created > 0;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        _dataContext.Products.Update(product);
        var updated = await _dataContext.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<bool> DeleteProductAsync(Guid productId)
    {
        var product = await GetProductByIdAsync(productId);
        if (product is null)
        {
            return false;
        }
        
        _dataContext.Products.Remove(product);
        var deleted = await _dataContext.SaveChangesAsync();
        return deleted > 0;
    }
}