using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IAsignacionService
{
    Task<IEnumerable<Asignacion>> ObtenerPorObraAsync(int obraId);
    Task<IEnumerable<Asignacion>> ObtenerPorEmpleadoAsync(int empleadoId);
    Task<Asignacion?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(Asignacion asignacion, int usuarioId);
    Task<(bool Success, string? Error)> EliminarAsync(int id);
}
