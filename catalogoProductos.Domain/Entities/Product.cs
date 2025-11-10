namespace catalogoProductos.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int SellerId { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    
    // Relations 1 : N
    public Seller Seller { get; set; } = null!;
}