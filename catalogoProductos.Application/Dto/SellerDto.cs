namespace catalogoProductos.Application.Dto;

public class SellerCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Store { get; set; } = string.Empty;
}

public class SellerUpdateDto
{
    public string Store { get; set; }
}