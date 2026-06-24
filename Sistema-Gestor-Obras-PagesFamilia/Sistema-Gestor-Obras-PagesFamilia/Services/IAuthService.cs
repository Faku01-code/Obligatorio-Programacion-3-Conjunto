using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IAuthService
{
    Task<(bool Success, Usuario? Usuario, string? Error)> ValidarCredencialesAsync(string email, string contrasenia);
    Task<Rol?> ObtenerRolAsync(int idRol);
    Task<IEnumerable<Rol>> ObtenerRolesAsync();
}
