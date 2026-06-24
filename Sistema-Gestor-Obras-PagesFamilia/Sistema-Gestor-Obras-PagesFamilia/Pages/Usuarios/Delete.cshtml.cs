using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Usuarios;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IUsuarioService _usuarioService;

    public DeleteModel(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [BindProperty]
    public Usuario Usuario { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var usuario = await _usuarioService.ObtenerPorIdAsync(id);
        if (usuario == null) return NotFound();
        Usuario = usuario;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var (success, error) = await _usuarioService.DarDeBajaAsync(Usuario.IdUsuario);
        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Usuario dado de baja.";
        return RedirectToPage("Index");
    }
}
