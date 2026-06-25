using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales.Compras;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly ICompraService _compraService;

    public DeleteModel(ICompraService compraService)
    {
        _compraService = compraService;
    }

    [BindProperty]
    public Compra Compra { get; set; } = null!;
    public string? ErrorMessage { get; set; }
    public int? ReturnObraId { get; set; }

    public async Task<IActionResult> OnGetAsync(int id, int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var compra = await _compraService.ObtenerPorIdAsync(id);
        if (compra == null) return NotFound();

        Compra = compra;
        ReturnObraId = returnObraId;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var (success, error) = await _compraService.EliminarAsync(Compra.IdCompra);

        if (!success)
        {
            ErrorMessage = error;
            var compra = await _compraService.ObtenerPorIdAsync(Compra.IdCompra);
            if (compra != null) Compra = compra;
            ReturnObraId = returnObraId;
            return Page();
        }

        TempData["Success"] = "Compra eliminada correctamente.";

        if (returnObraId.HasValue)
            return RedirectToPage("/Obras/Details", new { id = returnObraId });

        return RedirectToPage("/Obras/Index");
    }
}
