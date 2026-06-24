using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IObraService
{
    Task<IEnumerable<Obra>> ObtenerTodasAsync(bool soloActivas = true);
    Task<Obra?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(Obra obra, int usuarioId);
    Task<(bool Success, string? Error)> ActualizarAsync(Obra obra);
    Task<(bool Success, string? Error)> DarDeBajaAsync(int id);
    Task<int> ContarActivasAsync();
}
