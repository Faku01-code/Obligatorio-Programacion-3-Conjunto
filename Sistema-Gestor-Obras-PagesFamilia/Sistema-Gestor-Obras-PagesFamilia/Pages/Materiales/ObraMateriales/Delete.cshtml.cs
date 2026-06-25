using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales.ObraMateriales;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IObraMaterialService _obraMaterialService;

    public DeleteModel(IObraMaterialService obraMaterialService)
    {
        _obraMaterialService = obraMaterialService;
    }

    [BindProperty]
    public ObraMaterial ObraMaterial { get; set; } = null!;
    public string? ErrorMessage { get; set; }
    public int? ReturnObraId { get; set; }

    public async Task<IActionResult> OnGetAsync(int id, int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var om = await _obraMaterialService.ObtenerPorIdAsync(id);
        if (om == null) return NotFound();

        ObraMaterial = om;
        ReturnObraId = returnObraId;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var (success, error) = await _obraMaterialService.EliminarAsync(ObraMaterial.IdObraMaterial);

        if (!success)
        {
            var om = await _obraMaterialService.ObtenerPorIdAsync(ObraMaterial.IdObraMaterial);
            if (om != null) ObraMaterial = om;
            ErrorMessage = error;
            ReturnObraId = returnObraId;
            return Page();
        }

        TempData["Success"] = "Material quitado de la obra.";

        if (returnObraId.HasValue)
            return RedirectToPage("/Obras/Details", new { id = returnObraId });

        return RedirectToPage("/Obras/Index");
    }
}
