using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> ObtenerActivosAsync();
    Task<IEnumerable<Cliente>> ObtenerTodosAsync();
    Task<Cliente?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(Cliente cliente);
    Task<(bool Success, string? Error)> ActualizarAsync(Cliente cliente);
    Task<(bool Success, string? Error)> DarDeBajaAsync(int id);
}
