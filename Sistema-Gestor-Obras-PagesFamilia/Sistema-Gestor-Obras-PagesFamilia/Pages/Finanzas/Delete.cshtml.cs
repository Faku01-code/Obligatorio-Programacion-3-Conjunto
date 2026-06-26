using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Finanzas;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IMovimientoFinService _movimientoFinService;

    public DeleteModel(IMovimientoFinService movimientoFinService)
    {
        _movimientoFinService = movimientoFinService;
    }

    public MovimientoFin Movimiento { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var movimiento = await _movimientoFinService.ObtenerPorIdAsync(id);
        if (movimiento == null) return NotFound();
        if (movimiento.Compra != null) return RedirectToPage("/Finanzas/Index");

        Movimiento = movimiento;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var (ok, error) = await _movimientoFinService.EliminarAsync(id);
        if (!ok)
        {
            TempData["Error"] = error;
            return RedirectToPage("/Finanzas/Index");
        }

        TempData["Success"] = "Movimiento eliminado correctamente.";
        return RedirectToPage("/Finanzas/Index");
    }
}
