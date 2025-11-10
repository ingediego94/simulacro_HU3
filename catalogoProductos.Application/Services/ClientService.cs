using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;

namespace catalogoProductos.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }
    // --------------------------------------------------------
    
    // Get All:
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    // Get By Id:
    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    
    // Create:
    public Task<Client> CreateAsync(RegisterClientRequest dto)
    {
        throw new NotImplementedException();
    }

    // Update:
    public async Task<bool> UpdateAsync(int id, ClientUpdateDto dto)
    {
        var client = await _repository.GetByIdAsync(id);

        if (client == null)
            return false;
        //TODO:
        if (dto.Career != null) 
            student.Career = dto.Career;
        
        if (dto.Status.HasValue) 
            student.Status = dto.Status.Value;

        await _repository.UpdateAsync(client);
        return true;
    }

    //Delete:
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}