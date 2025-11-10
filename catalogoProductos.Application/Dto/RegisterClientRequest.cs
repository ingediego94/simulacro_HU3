namespace catalogoProductos.Application.Dto;

public record RegisterClientRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);