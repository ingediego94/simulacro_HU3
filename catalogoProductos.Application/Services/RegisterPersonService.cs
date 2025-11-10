using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;

namespace catalogoProductos.Application.Services;

public class RegisterPersonService : IRegisterPersonService
{
    private readonly IClientRepository _clientRepo;
    private readonly ISellerRepository _sellerRepo;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterPersonService(IClientRepository clientRepo, ISellerRepository sellerRepo, IPasswordHasher passwordHasher)
    {
        _clientRepo = clientRepo;
        _sellerRepo = sellerRepo;
        _passwordHasher = passwordHasher;
    }
    // --------------------------------------------------------
    
    public async Task<Client> RegisterClientAsync(RegisterPersonRequest request)
    {
        var client = new Client
        {
            Name = request.Name,
            LastName = request.LastName,
            DocNumber = request.DocNumber,
            Email = request.Email,
            UserName = request.UserName,
            Password = request.Password,
            Role = Role.client,
            Premium = request.Premium
        };

        await _clientRepo.AddAsync(client);
        return client;
    }

    public async Task<Seller> RegisterSellerAsync(RegisterPersonRequest request)
    {
        var seller = new Seller
        {
            Name = request.Name,
            LastName = request.LastName,
            DocNumber = request.DocNumber,
            Email = request.Email,
            UserName = request.UserName,
            Password = request.Password,
            Role = Role.seller,
            Store = request.Store
        };

        await _sellerRepo.AddAsync(seller);
        return seller;
    }
}