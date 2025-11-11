using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using catalogoProductos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace catalogoProductos.Application.Auth;

public class LoginService
{
    private readonly IUserRepository _userRepo;
    private readonly IAdminRepository _adminRepo;
    private readonly IConfiguration _config;

    public LoginService(IUserRepository userRepo, IAdminRepository adminRepo, IConfiguration config)
    {
        _userRepo = userRepo;
        _adminRepo = adminRepo;
        _config = config;
    }

    // -------------------------------------------------------
    public string GenerateToken(string role, int id)
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
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    
    //
    public async Task<string?> Login(string email, string password)
    {
        var admin = await _adminRepo.GetByEmailAsync(email);

        if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.Password))
            return GenerateToken("admin", admin.Id);
        
        return null;
    }
}