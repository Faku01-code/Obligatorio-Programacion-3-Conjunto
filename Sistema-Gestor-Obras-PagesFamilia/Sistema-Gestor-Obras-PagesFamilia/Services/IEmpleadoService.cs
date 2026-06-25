using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IEmpleadoService
{
    Task<IEnumerable<Empleado>> ObtenerTodosAsync(bool soloActivos = true);
    Task<Empleado?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(Empleado empleado);
    Task<(bool Success, string? Error)> ActualizarAsync(Empleado empleado);
    Task<(bool Success, string? Error)> DarDeBajaAsync(int id);
    Task<int> ContarActivosAsync();
}
