using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class ObraService : IObraService
{
    private readonly IObraRepository _obraRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IEstadoObraRepository _estadoObraRepository;

    public ObraService(
        IObraRepository obraRepository,
        IClienteRepository clienteRepository,
        IEstadoObraRepository estadoObraRepository)
    {
        _obraRepository = obraRepository;
        _clienteRepository = clienteRepository;
        _estadoObraRepository = estadoObraRepository;
    }

    public Task<IEnumerable<Obra>> ObtenerTodasAsync(bool soloActivas = true) =>
        _obraRepository.GetAllWithDetailsAsync(soloActivas);

    public Task<Obra?> ObtenerPorIdAsync(int id) =>
        _obraRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(Obra obra, int usuarioId)
    {
        var error = await ValidarObraAsync(obra);
        if (error != null) return (false, error);

        obra.Activo = true;
        obra.CreadoPor = usuarioId;
        obra.FechaCreacion = DateTime.Now;

        await _obraRepository.AddAsync(obra);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ActualizarAsync(Obra obra)
    {
        var existente = await _obraRepository.GetByIdAsync(obra.IdObra);
        if (existente == null)
            return (false, "La obra no existe.");

        var error = await ValidarObraAsync(obra);
        if (error != null) return (false, error);

        existente.Nombre = obra.Nombre;
        existente.Direccion = obra.Direccion;
        existente.Descripcion = obra.Descripcion;
        existente.FechaInicio = obra.FechaInicio;
        existente.FechaFinEstimada = obra.FechaFinEstimada;
        existente.IdCliente = obra.IdCliente;
        existente.IdEstado = obra.IdEstado;

        _obraRepository.Update(existente);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DarDeBajaAsync(int id)
    {
        var obra = await _obraRepository.GetByIdAsync(id);
        if (obra == null)
            return (false, "La obra no existe.");

        if (obra.Activo == false)
            return (false, "La obra ya está dada de baja.");

        obra.Activo = false;
        obra.FechaBaja = DateOnly.FromDateTime(DateTime.Today);
        _obraRepository.Update(obra);
        return (true, null);
    }

    public Task<int> ContarActivasAsync() =>
        _obraRepository.CountActivasAsync();

    private async Task<string?> ValidarObraAsync(Obra obra)
    {
        if (string.IsNullOrWhiteSpace(obra.Nombre))
            return "El nombre de la obra es obligatorio.";

        if (await _clienteRepository.GetByIdAsync(obra.IdCliente) == null)
            return "El cliente seleccionado no existe.";

        if (await _estadoObraRepository.GetByIdAsync(obra.IdEstado) == null)
            return "El estado seleccionado no existe.";

        if (obra.FechaInicio.HasValue && obra.FechaFinEstimada.HasValue
            && obra.FechaFinEstimada < obra.FechaInicio)
            return "La fecha fin estimada no puede ser anterior a la fecha de inicio.";

        return null;
    }
}
