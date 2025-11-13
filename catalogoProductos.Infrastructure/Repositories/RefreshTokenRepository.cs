using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using catalogoProductos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace catalogoProductos.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AppDbContext _context;

    public RefreshTokenRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ---------------------------------------------------------
    public async Task<RefreshToken?> GetByTokenAsync(string token)
        => await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == token);

    public async Task AddAsync(RefreshToken refreshToken)
        => await _context.RefreshTokens.AddAsync(refreshToken);

    public async Task RevokeAsync(RefreshToken refreshToken)
    {
        refreshToken.IsRevoked = true;
        _context.RefreshTokens.Update(refreshToken);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}