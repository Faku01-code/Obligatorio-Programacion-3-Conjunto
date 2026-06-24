using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRolRepository _rolRepository;

    public AuthService(IUsuarioRepository usuarioRepository, IRolRepository rolRepository)
    {
        _usuarioRepository = usuarioRepository;
        _rolRepository = rolRepository;
    }

    public async Task<(bool Success, Usuario? Usuario, string? Error)> ValidarCredencialesAsync(string email, string contrasenia)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasenia))
            return (false, null, "Email y contraseña son obligatorios.");

        var usuario = await _usuarioRepository.GetByEmailAsync(email.Trim());

        if (usuario == null)
            return (false, null, "Credenciales incorrectas.");

        if (usuario.Contrasenia != contrasenia)
            return (false, null, "Credenciales incorrectas.");

        return (true, usuario, null);
    }

    public async Task<Rol?> ObtenerRolAsync(int idRol) =>
        await _rolRepository.GetByIdAsync(idRol);

    public async Task<IEnumerable<Rol>> ObtenerRolesAsync() =>
        await _rolRepository.GetAllAsync();
}
