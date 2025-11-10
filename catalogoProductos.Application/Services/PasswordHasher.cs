using catalogoProductos.Application.Interfaces;

namespace catalogoProductos.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool verify(string hash, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}