using catalogoProductos.Application.Dto;
using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Application.Interfaces;

public interface ISellerService
{
    Task<IEnumerable<Seller>> GetAllAsync();
    Task<Seller?> GetByIdAsync(int id);
    Task<Seller> CreateAsync(SellerCreateDto dto);
    Task<bool> UpdateAsync(int id, SellerUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}