using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class AsignacionService : IAsignacionService
{
    private readonly IAsignacionRepository _asignacionRepository;
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IObraRepository _obraRepository;

    public AsignacionService(
        IAsignacionRepository asignacionRepository,
        IEmpleadoRepository empleadoRepository,
        IObraRepository obraRepository)
    {
        _asignacionRepository = asignacionRepository;
        _empleadoRepository = empleadoRepository;
        _obraRepository = obraRepository;
    }

    public Task<IEnumerable<Asignacion>> ObtenerPorObraAsync(int obraId) =>
        _asignacionRepository.GetByObraIdAsync(obraId);

    public Task<IEnumerable<Asignacion>> ObtenerPorEmpleadoAsync(int empleadoId) =>
        _asignacionRepository.GetByEmpleadoIdAsync(empleadoId);

    public Task<Asignacion?> ObtenerPorIdAsync(int id) =>
        _asignacionRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(Asignacion asignacion, int usuarioId)
    {
        var error = await ValidarAsync(asignacion);
        if (error != null) return (false, error);

        asignacion.CreadoPor = usuarioId;
        asignacion.FechaCreacion = DateTime.Now;

        await _asignacionRepository.AddAsync(asignacion);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> EliminarAsync(int id)
    {
        var asignacion = await _asignacionRepository.GetByIdAsync(id);
        if (asignacion == null) return (false, "La asignación no existe.");

        if (await _asignacionRepository.TieneRegistroHorasAsync(id))
            return (false, "No se puede eliminar: tiene registros de horas asociados.");

        _asignacionRepository.Remove(asignacion);
        return (true, null);
    }

    private async Task<string?> ValidarAsync(Asignacion a)
    {
        if (await _empleadoRepository.GetByIdAsync(a.IdEmpleado) == null)
            return "El empleado seleccionado no existe.";

        if (await _obraRepository.GetByIdAsync(a.IdObra) == null)
            return "La obra seleccionada no existe.";

        if (a.FechaFin.HasValue && a.FechaFin < a.FechaInicio)
            return "La fecha de fin no puede ser anterior a la fecha de inicio.";

        return null;
    }
}
