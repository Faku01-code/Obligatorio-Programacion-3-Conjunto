using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _empleadoRepository;

    public EmpleadoService(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public Task<IEnumerable<Empleado>> ObtenerTodosAsync(bool soloActivos = true) =>
        _empleadoRepository.GetAllWithDetailsAsync(soloActivos);

    public Task<Empleado?> ObtenerPorIdAsync(int id) =>
        _empleadoRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(Empleado empleado)
    {
        var error = await ValidarAsync(empleado);
        if (error != null) return (false, error);

        empleado.Activo = true;
        await _empleadoRepository.AddAsync(empleado);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ActualizarAsync(Empleado empleado)
    {
        var existente = await _empleadoRepository.GetByIdAsync(empleado.IdEmpleado);
        if (existente == null) return (false, "El empleado no existe.");

        var error = await ValidarAsync(empleado, existente.IdEmpleado);
        if (error != null) return (false, error);

        existente.Nombre = empleado.Nombre;
        existente.Documento = empleado.Documento;
        existente.Telefono = empleado.Telefono;
        existente.Tipo = empleado.Tipo;
        existente.IdOficio = empleado.IdOficio;

        _empleadoRepository.Update(existente);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DarDeBajaAsync(int id)
    {
        var empleado = await _empleadoRepository.GetByIdAsync(id);
        if (empleado == null) return (false, "El empleado no existe.");
        if (empleado.Activo == false) return (false, "El empleado ya está dado de baja.");

        empleado.Activo = false;
        empleado.FechaBaja = DateOnly.FromDateTime(DateTime.Today);
        _empleadoRepository.Update(empleado);
        return (true, null);
    }

    public Task<int> ContarActivosAsync() =>
        _empleadoRepository.CountActivosAsync();

    private async Task<string?> ValidarAsync(Empleado empleado, int idPropio = 0)
    {
        if (string.IsNullOrWhiteSpace(empleado.Nombre))
            return "El nombre es obligatorio.";

        if (empleado.Tipo is not ("FIJO" or "SUBCONTRATISTA"))
            return "El tipo debe ser FIJO o SUBCONTRATISTA.";

        if (!string.IsNullOrWhiteSpace(empleado.Documento))
        {
            var documentoExiste = await _empleadoRepository.AnyAsync(
                e => e.Documento == empleado.Documento && e.IdEmpleado != idPropio);
            if (documentoExiste)
                return "Ya existe un empleado con ese documento.";
        }

        return null;
    }
}
