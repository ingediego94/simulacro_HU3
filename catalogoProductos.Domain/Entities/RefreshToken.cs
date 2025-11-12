namespace catalogoProductos.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public int UserId { get; set; } // o AdminId según tu caso
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public bool IsRevoked { get; set; } = false;

    public bool IsExpired => DateTime.UtcNow >= Expires;
}