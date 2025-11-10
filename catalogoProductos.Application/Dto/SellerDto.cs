namespace catalogoProductos.Application.Dto;

public class SellerCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Career { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}

public class SellerUpdateDto
{
    public string? Specialization { get; set; }
}