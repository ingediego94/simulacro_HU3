namespace catalogoProductos.Domain.Entities;

public class Client : User
{
    public bool Premium { get; set; }
    
    // Relation:
    public ICollection<Sales> Sales { get; set; } = new List<Sales>();
}