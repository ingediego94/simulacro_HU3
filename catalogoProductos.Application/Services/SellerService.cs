using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;

namespace catalogoProductos.Application.Services;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _repository;

    public SellerService(ISellerRepository repository)
    {
        _repository = repository;
    }
    
    // ----------------------------------------------
    
    // Get All:
    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    
    // Get By Id:
    public async Task<Seller?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    
    // Create
    public Task<Seller> CreateAsync(SellerCreateDto dto)
    {
        throw new NotImplementedException();
    }

    
    // Update:
    public async Task<bool> UpdateAsync(int id, SellerUpdateDto dto)
    {
        var seller = await _repository.GetByIdAsync(id);

        if (seller == null)
            return false;

        if (dto.Store != null) seller.Store = dto.Store;

        await _repository.UpdateAsync(seller);
        return true;
    }

    
    // Delete:
    public async Task<bool> DeleteAsync(int id)
    {
        var seller = await _repository.GetByIdAsync(id);

        if (seller == null)
            return false;

        await _repository.DeleteAsync(seller.Id);
        return true;
    }
}