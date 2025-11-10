namespace catalogoProductos.Application.Dto;

public class ClientCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Career { get; set; } = string.Empty;
    public bool? Premium { get; set; }
}

public class ClientUpdateDto
{
    public bool? Premium { get; set; }
}