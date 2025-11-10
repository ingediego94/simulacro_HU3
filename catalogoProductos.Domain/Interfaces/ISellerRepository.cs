using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Domain.Interfaces;

public interface ISellerRepository
{
    Task<Seller?> GetByIdAsync(int id);
    Task<IEnumerable<Seller>> GetAllAsync();
    Task<Seller> AddAsync(Seller seller);
    Task<Seller?> UpdateAsync(Seller seller);
    Task<bool> DeleteAsync(int id);
}