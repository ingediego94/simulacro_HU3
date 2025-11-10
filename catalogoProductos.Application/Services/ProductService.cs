using catalogoProductos.Application.Interfaces;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;

namespace catalogoProductos.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    
    // ------------------------------------------------
    //Get By Id:
    public async Task<Product> GetByIdAsync_(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    
    // Get All
    public async Task<IEnumerable<Product>> GetAllAsync_()
    {
        return await _productRepository.GetAllAsync();
    }

    
    // Create:
    public async Task<Product> CreateAsync_(Product product)
    {
        return await _productRepository.CreateAsync(product);
    }

    
    // Update:
    public async Task<bool> UpdateAsync_(Product product)
    {
        var exists = await _productRepository.GetByIdAsync(product.Id);

        if (product == null)
            return false;

        await _productRepository.UpdateAsync(product);
        return true;
    }

    
    // Delete:
    public async Task<bool> DeleteAsync_(int id)
    {
        var existing = await _productRepository.GetByIdAsync(id);

        if (existing == null)
            return false;

        await _productRepository.DeleteAsync(id);
        return true;
    }
}