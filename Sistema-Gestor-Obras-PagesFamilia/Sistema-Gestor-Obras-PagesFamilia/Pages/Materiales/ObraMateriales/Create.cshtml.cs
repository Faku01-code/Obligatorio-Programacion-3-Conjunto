using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales.ObraMateriales;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IObraMaterialService _obraMaterialService;
    private readonly IMaterialService _materialService;

    public CreateModel(IObraMaterialService obraMaterialService, IMaterialService materialService)
    {
        _obraMaterialService = obraMaterialService;
        _materialService = materialService;
    }

    [BindProperty]
    public ObraMaterialFormViewModel Input { get; set; } = new();
    public SelectList Materiales { get; set; } = null!;
    public string? ErrorMessage { get; set; }
    public int? ReturnObraId { get; set; }

    public async Task<IActionResult> OnGetAsync(int obraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        ReturnObraId = obraId;
        Input.IdObra = obraId;

        await CargarSelectsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        await CargarSelectsAsync();

        if (!ModelState.IsValid) return Page();

        var obraMaterial = new ObraMaterial
        {
            IdObra = Input.IdObra,
            IdMaterial = Input.IdMaterial,
            CantRequerida = Input.CantRequerida
        };

        var (success, error) = await _obraMaterialService.CrearAsync(obraMaterial);

        if (!success)
        {
            ErrorMessage = error;
            ReturnObraId = returnObraId;
            return Page();
        }

        TempData["Success"] = "Material agregado a la obra correctamente.";

        if (returnObraId.HasValue)
            return RedirectToPage("/Obras/Details", new { id = returnObraId });

        return RedirectToPage("/Obras/Index");
    }

    private async Task CargarSelectsAsync()
    {
        var materiales = await _materialService.ObtenerTodosAsync(soloActivos: true);
        Materiales = new SelectList(materiales, "IdMaterial", "Nombre", Input.IdMaterial);
    }
}
