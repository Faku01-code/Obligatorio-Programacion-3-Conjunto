using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IMaterialService _materialService;

    public IndexModel(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    public IEnumerable<Material> Materiales { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        Materiales = await _materialService.ObtenerTodosAsync(soloActivos: !EsAdministrador);
        return Page();
    }
}
