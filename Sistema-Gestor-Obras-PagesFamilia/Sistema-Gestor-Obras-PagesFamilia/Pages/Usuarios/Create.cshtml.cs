using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Usuarios;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IUsuarioService _usuarioService;
    private readonly IRolRepository _rolRepository;

    public CreateModel(IUsuarioService usuarioService, IRolRepository rolRepository)
    {
        _usuarioService = usuarioService;
        _rolRepository = rolRepository;
    }

    [BindProperty]
    public UsuarioFormViewModel Input { get; set; } = new();

    public IList<Rol> Roles { get; set; } = [];
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        Roles = (await _rolRepository.GetAllAsync()).ToList();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        Roles = (await _rolRepository.GetAllAsync()).ToList();

        if (string.IsNullOrWhiteSpace(Input.Contrasenia))
            ModelState.AddModelError("Input.Contrasenia", "La contraseña es obligatoria.");

        if (!ModelState.IsValid) return Page();

        var (success, error) = await _usuarioService.CrearAsync(new Usuario
        {
            Email = Input.Email.Trim(),
            Contrasenia = Input.Contrasenia
        }, Input.RolesSeleccionados);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Usuario creado.";
        return RedirectToPage("Index");
    }
}
