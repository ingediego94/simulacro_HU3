namespace catalogoProductos.Application.Dto;


public record RegisterSellerRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
