using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Domain.Interfaces;

public interface IAdminRepository
{
    Task<Admin?> GetByEmailAsync(string email);
    Task AddAsync(Admin admin);
}