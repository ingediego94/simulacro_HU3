namespace catalogoProductos.Domain.Entities;

public class Sales
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    public int TotalPrice { get; set; }
    public DateTime SaleDate { get; set; }
    
    // Relation 1:N
    public Client Client { get; set; } = null!;
    public Product Product { get; set; } = null!;
}