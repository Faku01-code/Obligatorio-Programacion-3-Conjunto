using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;

    public IndexModel(IObraService obraService)
    {
        _obraService = obraService;
    }

    public IList<Obra> Obras { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        Obras = (await _obraService.ObtenerTodasAsync(soloActivas: !EsAdministrador)).ToList();

        return Page();
    }
}
