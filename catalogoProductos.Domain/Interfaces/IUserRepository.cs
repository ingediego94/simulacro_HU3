using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
}