namespace catalogoProductos.Application.Dto;

public class RegisterPersonRequest
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DocNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    // Only for Clients:
    public bool Premium { get; set; }


    // Only for Sellers:
    public string Store { get; set; } = string.Empty;
}