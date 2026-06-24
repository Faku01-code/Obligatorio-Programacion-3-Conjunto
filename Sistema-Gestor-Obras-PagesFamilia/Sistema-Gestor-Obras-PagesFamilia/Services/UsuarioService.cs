using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly PagesFamiliaContext _context;

    public UsuarioService(IUsuarioRepository usuarioRepository, PagesFamiliaContext context)
    {
        _usuarioRepository = usuarioRepository;
        _context = context;
    }

    public Task<IEnumerable<Usuario>> ObtenerTodosAsync() =>
        _usuarioRepository.GetAllWithRolesAsync();

    public Task<Usuario?> ObtenerPorIdAsync(int id) =>
        _usuarioRepository.GetByIdWithRolesAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(Usuario usuario, IEnumerable<int> rolesIds)
    {
        var error = ValidarUsuario(usuario, rolesIds);
        if (error != null) return (false, error);

        if (await _usuarioRepository.AnyAsync(u => u.Email == usuario.Email))
            return (false, "Ya existe un usuario con ese email.");

        usuario.Activo = true;
        usuario.FechaCreacion = DateTime.Now;

        var roles = await _context.Rols
            .Where(r => rolesIds.Contains(r.IdRol))
            .ToListAsync();

        if (roles.Count == 0)
            return (false, "Debe asignar al menos un rol.");

        usuario.IdRols = roles;
        await _usuarioRepository.AddAsync(usuario);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ActualizarAsync(
        Usuario usuario, IEnumerable<int> rolesIds, bool cambiarContrasenia)
    {
        var existente = await _usuarioRepository.GetByIdWithRolesAsync(usuario.IdUsuario);
        if (existente == null)
            return (false, "El usuario no existe.");

        if (string.IsNullOrWhiteSpace(usuario.Email))
            return (false, "El email es obligatorio.");

        if (await _usuarioRepository.AnyAsync(u => u.Email == usuario.Email && u.IdUsuario != usuario.IdUsuario))
            return (false, "Ya existe otro usuario con ese email.");

        var roles = await _context.Rols
            .Where(r => rolesIds.Contains(r.IdRol))
            .ToListAsync();

        if (roles.Count == 0)
            return (false, "Debe asignar al menos un rol.");

        existente.Email = usuario.Email.Trim();
        if (cambiarContrasenia && !string.IsNullOrWhiteSpace(usuario.Contrasenia))
            existente.Contrasenia = usuario.Contrasenia;

        existente.IdRols.Clear();
        foreach (var rol in roles)
            existente.IdRols.Add(rol);

        _usuarioRepository.Update(existente);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DarDeBajaAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null)
            return (false, "El usuario no existe.");

        if (id == 1)
            return (false, "No se puede dar de baja al usuario administrador principal.");

        usuario.Activo = false;
        _usuarioRepository.Update(usuario);
        return (true, null);
    }

    private static string? ValidarUsuario(Usuario usuario, IEnumerable<int> rolesIds)
    {
        if (string.IsNullOrWhiteSpace(usuario.Email))
            return "El email es obligatorio.";
        if (string.IsNullOrWhiteSpace(usuario.Contrasenia))
            return "La contraseña es obligatoria.";
        if (!rolesIds.Any())
            return "Debe asignar al menos un rol.";
        return null;
    }
}
