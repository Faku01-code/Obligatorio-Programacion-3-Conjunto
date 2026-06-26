using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Finanzas;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IMovimientoFinService _movimientoFinService;

    public IndexModel(IMovimientoFinService movimientoFinService)
    {
        _movimientoFinService = movimientoFinService;
    }

    public IEnumerable<MovimientoFin> Movimientos { get; set; } = [];
    public decimal TotalIngresos { get; set; }
    public decimal TotalEgresos { get; set; }
    public decimal Balance => TotalIngresos - TotalEgresos;

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        Movimientos = await _movimientoFinService.ObtenerTodosAsync();
        (TotalIngresos, TotalEgresos) = await _movimientoFinService.ObtenerResumenGlobalAsync();
        return Page();
    }
}
