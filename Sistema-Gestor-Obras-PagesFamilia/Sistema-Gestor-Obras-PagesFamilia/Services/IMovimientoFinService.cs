using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IMovimientoFinService
{
    Task<IEnumerable<MovimientoFin>> ObtenerTodosAsync();
    Task<IEnumerable<MovimientoFin>> ObtenerPorObraAsync(int obraId);
    Task<MovimientoFin?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(MovimientoFinFormViewModel vm, int usuarioId);
    Task<(bool Success, string? Error)> EliminarAsync(int id);
    Task<(decimal TotalIngresos, decimal TotalEgresos)> ObtenerResumenGlobalAsync();
    Task<(decimal TotalIngresos, decimal TotalEgresos)> ObtenerResumenPorObraAsync(int obraId);
}
