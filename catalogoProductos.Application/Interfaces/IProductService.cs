using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Application.Interfaces;

public interface IProductService
{
    Task<Product> GetByIdAsync_(int id);
    Task<IEnumerable<Product>> GetAllAsync_();
    Task<Product> CreateAsync_(Product product);
    Task<bool> UpdateAsync_(Product product);
    Task<bool> DeleteAsync_(int id);
}