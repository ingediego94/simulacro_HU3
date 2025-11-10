using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace catalogoProductos.Infrastructure.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly AppDbContext _context;

    public SellerRepository(AppDbContext context)
    {
        _context = context;
    }
    // ------------------------------------------------
    
    // Get All:
    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        return await _context.Sellers.ToListAsync();
    }

    
    // Get By Id:
    public async Task<Seller?> GetByIdAsync(int id)
    {
        return await _context.Sellers.FindAsync(id);
    }

    
    // Create:
    public async Task<Seller> AddAsync(Seller seller)
    {
        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync();
        return seller;
    }

    
    // Update:
    public async Task<Seller?> UpdateAsync(Seller seller)
    {
        var exist = await _context.Sellers.FindAsync(seller.Id);

        if (exist == null)
            return null;
        
        exist.Name = seller.Name;
        exist.LastName = seller.LastName;
        exist.DocNumber = seller.DocNumber;
        exist.Email = seller.Email;
        exist.UserName = seller.UserName;
        exist.Password = seller.Password;
        exist.Store = seller.Store;

        await _context.SaveChangesAsync();
        return seller;
        
    }

    
    // Delete:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.Sellers.FindAsync(id);

        if (toDelete == null)
            return false;

        _context.Sellers.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
    
}