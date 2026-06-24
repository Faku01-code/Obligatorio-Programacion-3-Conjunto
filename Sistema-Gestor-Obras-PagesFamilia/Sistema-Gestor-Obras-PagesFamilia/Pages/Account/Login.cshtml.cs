using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema_Gestor_Obras_PagesFamilia.Helpers;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Account;

public class LoginModel : PageModel
{
    private readonly IAuthService _authService;

    public LoginModel(IAuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public LoginViewModel Input { get; set; } = new();

    public List<RolLoginOption> RolesDisponibles { get; set; } = [];
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Session.GetInt32(SessionKeys.UsuarioId) != null)
            return RedirectToPage("/Index");

        await CargarRolesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await CargarRolesAsync();

        if (!ModelState.IsValid)
            return Page();

        var (success, usuario, error) = await _authService.ValidarCredencialesAsync(Input.Email, Input.Contrasenia);
        if (!success || usuario == null)
        {
            ErrorMessage = error;
            return Page();
        }

        var rol = await _authService.ObtenerRolAsync(Input.IdRol);
        if (rol == null)
        {
            ErrorMessage = "El rol seleccionado no es válido.";
            return Page();
        }

        HttpContext.Session.SetInt32(SessionKeys.UsuarioId, usuario.IdUsuario);
        HttpContext.Session.SetString(SessionKeys.UsuarioEmail, usuario.Email);
        HttpContext.Session.SetInt32(SessionKeys.RolId, rol.IdRol);
        HttpContext.Session.SetString(SessionKeys.RolNombre, rol.Nombre);

        return RedirectToPage("/Index");
    }

    private async Task CargarRolesAsync()
    {
        var roles = await _authService.ObtenerRolesAsync();
        RolesDisponibles = roles.Select(r => new RolLoginOption
        {
            IdRol = r.IdRol,
            Nombre = r.Nombre,
            Descripcion = r.Descripcion
        }).ToList();
    }
}
