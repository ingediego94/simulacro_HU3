namespace catalogoProductos.Application.Interfaces;

public interface IAdminService
{
    Task<bool> RegisterAdmin(string email, string password);
}