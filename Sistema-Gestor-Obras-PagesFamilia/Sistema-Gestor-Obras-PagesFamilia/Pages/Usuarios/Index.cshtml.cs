using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Usuarios;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IUsuarioService _usuarioService;

    public IndexModel(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public IList<Usuario> Usuarios { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        Usuarios = (await _usuarioService.ObtenerTodosAsync()).ToList();
        return Page();
    }
}
