using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace catalogoProductos.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ----------------------------------------
    public async Task AddAsync(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
    }

    public async Task<Admin?> GetByEmailAsync(string email)
    {
        return await _context.Admins.FirstOrDefaultAsync(x => x.Email == email); 
    }


}