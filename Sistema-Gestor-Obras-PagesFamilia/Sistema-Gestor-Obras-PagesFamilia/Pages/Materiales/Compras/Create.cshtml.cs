using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales.Compras;

public class CreateModel : AuthenticatedPageModel
{
    private readonly ICompraService _compraService;
    private readonly IObraMaterialService _obraMaterialService;

    public CreateModel(ICompraService compraService, IObraMaterialService obraMaterialService)
    {
        _compraService = compraService;
        _obraMaterialService = obraMaterialService;
    }

    [BindProperty]
    public CompraFormViewModel Input { get; set; } = new();
    public ObraMaterial ObraMaterial { get; set; } = null!;
    public string? ErrorMessage { get; set; }
    public int? ReturnObraId { get; set; }

    public async Task<IActionResult> OnGetAsync(int obraMaterialId, int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var om = await _obraMaterialService.ObtenerPorIdAsync(obraMaterialId);
        if (om == null) return NotFound();

        ObraMaterial = om;
        ReturnObraId = returnObraId;
        Input.IdObraMaterial = obraMaterialId;
        Input.Fecha = DateOnly.FromDateTime(DateTime.Today);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var om = await _obraMaterialService.ObtenerPorIdAsync(Input.IdObraMaterial);
        if (om == null) return NotFound();
        ObraMaterial = om;
        ReturnObraId = returnObraId;

        if (!ModelState.IsValid) return Page();

        var (success, error) = await _compraService.CrearAsync(Input, UsuarioId);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Compra registrada correctamente.";

        if (returnObraId.HasValue)
            return RedirectToPage("/Obras/Details", new { id = returnObraId });

        return RedirectToPage("/Obras/Index");
    }
}
