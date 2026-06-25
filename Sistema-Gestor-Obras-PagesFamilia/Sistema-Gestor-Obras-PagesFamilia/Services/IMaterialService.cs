using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IMaterialService
{
    Task<IEnumerable<Material>> ObtenerTodosAsync(bool soloActivos = true);
    Task<Material?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(Material material);
    Task<(bool Success, string? Error)> ActualizarAsync(Material material);
    Task<(bool Success, string? Error)> DarDeBajaAsync(int id);
}
