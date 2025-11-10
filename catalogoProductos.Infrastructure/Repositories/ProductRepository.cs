using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace catalogoProductos.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ---------------------------------
    // Get By Id:
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    
    // Get All:
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    
    // Create:
    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    
    // Update:
    public async Task<Product?> UpdateAsync(Product product)
    {
        var exist = await _context.Products.FindAsync(product.Id);

        if (exist == null)
            return null;

        exist.ProductName = product.ProductName;
        exist.Code = product.Code;
        exist.SellerId = product.SellerId;
        exist.Stock = product.Stock;
        exist.Price = product.Price;

        await _context.SaveChangesAsync();
        return product;
    }

    
    // Delete:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.Products.FindAsync(id);

        if (toDelete == null)
            return false;

        _context.Products.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}