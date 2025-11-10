namespace catalogoProductos.Application.Dto;

public class ClientCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Career { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}

public class ClientUpdateDto
{
    public string? Career { get; set; }
    public DateTime? StartDate { get; set; }
    public bool? Status { get; set; }
}