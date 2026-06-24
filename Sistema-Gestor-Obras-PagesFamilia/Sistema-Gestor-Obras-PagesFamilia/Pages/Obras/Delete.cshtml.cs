using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;

    public DeleteModel(IObraService obraService)
    {
        _obraService = obraService;
    }

    [BindProperty]
    public Obra Obra { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var obra = await _obraService.ObtenerPorIdAsync(id);
        if (obra == null) return NotFound();

        Obra = obra;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var (success, error) = await _obraService.DarDeBajaAsync(Obra.IdObra);
        if (!success)
        {
            ErrorMessage = error;
            var obra = await _obraService.ObtenerPorIdAsync(Obra.IdObra);
            if (obra != null) Obra = obra;
            return Page();
        }

        TempData["Success"] = "Obra dada de baja correctamente.";
        return RedirectToPage("Index");
    }
}
