namespace catalogoProductos.Domain.Entities;

public class Seller : User
{
    public string Store { get; set; } = string.Empty;
    
    // Inverse relation
    public ICollection<Product> Products { get; set; } = new List<Product>();
}