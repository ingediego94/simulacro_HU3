using catalogoProductos.Application.Dto;
using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Application.Interfaces;

public interface IRegisterPersonService
{
    Task<Client> RegisterClientAsync(RegisterPersonRequest request);
    Task<Seller> RegisterSellerAsync(RegisterPersonRequest request);
}