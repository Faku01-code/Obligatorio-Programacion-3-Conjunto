using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public Task<IEnumerable<Cliente>> ObtenerActivosAsync() =>
        _clienteRepository.GetAllActiveAsync();

    public Task<IEnumerable<Cliente>> ObtenerTodosAsync() =>
        _clienteRepository.GetAllAsync();

    public Task<Cliente?> ObtenerPorIdAsync(int id) =>
        _clienteRepository.GetByIdAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(Cliente cliente)
    {
        var error = ValidarCliente(cliente);
        if (error != null) return (false, error);

        cliente.Activo = true;
        await _clienteRepository.AddAsync(cliente);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ActualizarAsync(Cliente cliente)
    {
        var existente = await _clienteRepository.GetByIdAsync(cliente.IdCliente);
        if (existente == null)
            return (false, "El cliente no existe.");

        var error = ValidarCliente(cliente);
        if (error != null) return (false, error);

        existente.Nombre = cliente.Nombre;
        existente.Telefono = cliente.Telefono;
        existente.Email = cliente.Email;

        _clienteRepository.Update(existente);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DarDeBajaAsync(int id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null)
            return (false, "El cliente no existe.");

        cliente.Activo = false;
        _clienteRepository.Update(cliente);
        return (true, null);
    }

    private static string? ValidarCliente(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            return "El nombre del cliente es obligatorio.";
        return null;
    }
}
