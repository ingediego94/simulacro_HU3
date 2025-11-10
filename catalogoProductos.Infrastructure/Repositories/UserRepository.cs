using Microsoft.EntityFrameworkCore;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Data;

namespace catalogoProductos.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
}