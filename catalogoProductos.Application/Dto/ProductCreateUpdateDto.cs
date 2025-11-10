namespace catalogoProductos.Application.Dto;

public class ProductCreateUpdateDto
{
    public string ProductName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int SellerId { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}