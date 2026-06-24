using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ObtenerTodosAsync();
    Task<Usuario?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(Usuario usuario, IEnumerable<int> rolesIds);
    Task<(bool Success, string? Error)> ActualizarAsync(Usuario usuario, IEnumerable<int> rolesIds, bool cambiarContrasenia);
    Task<(bool Success, string? Error)> DarDeBajaAsync(int id);
}
