using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace catalogoProductos.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }
    // ------------------------------------------------
    
    // Get All:
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    
    // Get By Id:
    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    
    // Create:
    public async Task<Client> AddAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    
    // Update:
    public async Task<Client?> UpdateAsync(Client client)
    {
        var exist = await _context.Clients.FindAsync(client.Id);

        if (exist == null)
            return null;
        
        exist.Name = client.Name;
        exist.LastName = client.LastName;
        exist.DocNumber = client.DocNumber;
        exist.Email = client.Email;
        exist.UserName = client.UserName;
        exist.Password = client.Password;
        exist.Premium = client.Premium;

        await _context.SaveChangesAsync();
        return client;
        
    }

    
    // Delete:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.Clients.FindAsync(id);

        if (toDelete == null)
            return false;

        _context.Clients.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
    
}