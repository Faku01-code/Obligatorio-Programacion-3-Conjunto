using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;

    public DetailsModel(IObraService obraService)
    {
        _obraService = obraService;
    }

    public Obra Obra { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        var obra = await _obraService.ObtenerPorIdAsync(id);
        if (obra == null) return NotFound();

        Obra = obra;
        return Page();
    }
}
