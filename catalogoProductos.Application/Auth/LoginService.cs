using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using catalogoProductos.Domain.Entities;
using catalogoProductos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace catalogoProductos.Application.Auth;

public class LoginService
{
    private readonly IUserRepository _userRepo;
    private readonly IAdminRepository _adminRepo;
    private readonly IRefreshTokenRepository _refreshRepo;
    private readonly IConfiguration _config;
    
    public LoginService(IUserRepository userRepo, IAdminRepository adminRepo, IRefreshTokenRepository refreshRepo, IConfiguration config)
    {
        _userRepo = userRepo;
        _adminRepo = adminRepo;
        _refreshRepo = refreshRepo;
        _config = config;
    }
    // -------------------------------------------------------
    public string GenerateAccessToken(string role, int id)
    {
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("id", id.ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),     // Duration of token (min)
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    // ------------------------------------------
    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<(string? AccessToken, string? RefreshToken)> LoginWithRefreshAsync(string email, string password)
    {
        var admin = await _adminRepo.GetByEmailAsync(email);
        if (admin == null || !BCrypt.Net.BCrypt.Verify(password, admin.Password))
            return (null, null);

        // Generar tokens
        var accessToken = GenerateAccessToken("admin", admin.Id);
        var refreshToken = GenerateRefreshToken();

        var refreshEntity = new RefreshToken
        {
            UserId = admin.Id,
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(7) // Duration of refresh token (days)
        };

        await _refreshRepo.AddAsync(refreshEntity);
        await _refreshRepo.SaveChangesAsync();

        return (accessToken, refreshToken);
    }
    
    public async Task<string?> RefreshAccessTokenAsync(string refreshToken)
    {
        var storedToken = await _refreshRepo.GetByTokenAsync(refreshToken);

        // Validar token
        if (storedToken == null || storedToken.IsRevoked || storedToken.IsExpired)
            return null;

        // Opcional: revocar token antiguo
        await _refreshRepo.RevokeAsync(storedToken);
        await _refreshRepo.SaveChangesAsync();

        // Crear nuevo token de acceso
        var newAccessToken = GenerateAccessToken("admin", storedToken.UserId);

        return newAccessToken;
    }

    
    //-------------------------------------------
    // public async Task<string?> Login(string email, string password)
    // {
    //     var admin = await _adminRepo.GetByEmailAsync(email);
    //
    //     if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.Password))
    //         return GenerateToken("admin", admin.Id);
    //     
    //     return null;
    // }
    
    
    // Logout
    public async Task<bool> LogoutAsync(string refreshToken)
    {
        var storedToken = await _refreshRepo.GetByTokenAsync(refreshToken);

        // Validar si el token existe o ya fue revocado
        if (storedToken == null || storedToken.IsRevoked)
            return false;

        // Revocar el token
        await _refreshRepo.RevokeAsync(storedToken);
        await _refreshRepo.SaveChangesAsync();

        return true;
    }
}