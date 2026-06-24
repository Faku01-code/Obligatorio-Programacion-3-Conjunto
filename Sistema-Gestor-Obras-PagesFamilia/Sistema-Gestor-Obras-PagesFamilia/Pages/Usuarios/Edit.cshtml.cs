using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Usuarios;

public class EditModel : AuthenticatedPageModel
{
    private readonly IUsuarioService _usuarioService;
    private readonly IRolRepository _rolRepository;

    public EditModel(IUsuarioService usuarioService, IRolRepository rolRepository)
    {
        _usuarioService = usuarioService;
        _rolRepository = rolRepository;
    }

    [BindProperty]
    public UsuarioFormViewModel Input { get; set; } = new();

    public IList<Rol> Roles { get; set; } = [];
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var usuario = await _usuarioService.ObtenerPorIdAsync(id);
        if (usuario == null) return NotFound();

        Roles = (await _rolRepository.GetAllAsync()).ToList();
        Input = new UsuarioFormViewModel
        {
            IdUsuario = usuario.IdUsuario,
            Email = usuario.Email,
            RolesSeleccionados = usuario.IdRols.Select(r => r.IdRol).ToList()
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        Roles = (await _rolRepository.GetAllAsync()).ToList();
        if (!ModelState.IsValid) return Page();

        var (success, error) = await _usuarioService.ActualizarAsync(new Usuario
        {
            IdUsuario = Input.IdUsuario,
            Email = Input.Email.Trim(),
            Contrasenia = Input.Contrasenia
        }, Input.RolesSeleccionados, Input.CambiarContrasenia);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Usuario actualizado.";
        return RedirectToPage("Index");
    }
}
