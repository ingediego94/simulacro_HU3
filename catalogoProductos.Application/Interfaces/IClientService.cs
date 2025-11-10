using catalogoProductos.Application.Dto;
using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<Client> CreateAsync(RegisterClientRequest dto);
    Task<bool> UpdateAsync(int id, ClientUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}