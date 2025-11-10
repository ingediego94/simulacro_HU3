using catalogoProductos.Application.Interfaces;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using catalogoProductos.Domain.Interfaces;

namespace catalogoProductos.Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repo;
    private readonly IConfiguration _config;

    public AdminService(IAdminRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public async Task<bool> RegisterAdmin(string email, string password)
    {
        // Verificar si ya existe
        var exists = await _repo.GetByEmailAsync(email);
        if (exists != null) return false;

        var admin = new Admin
        {
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password)
        };

        // Guardar
        await _repo.AddAsync(admin);
        return true;
    }

    public Task AddAsync(Admin admin)
    {
        throw new NotImplementedException();
    }
}