using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;
    private readonly IAsignacionService _asignacionService;
    private readonly IObraMaterialService _obraMaterialService;
    private readonly IMovimientoFinService _movimientoFinService;

    public DetailsModel(
        IObraService obraService,
        IAsignacionService asignacionService,
        IObraMaterialService obraMaterialService,
        IMovimientoFinService movimientoFinService)
    {
        _obraService = obraService;
        _asignacionService = asignacionService;
        _obraMaterialService = obraMaterialService;
        _movimientoFinService = movimientoFinService;
    }

    public Obra Obra { get; set; } = null!;
    public IEnumerable<Asignacion> Asignaciones { get; set; } = [];
    public IEnumerable<ObraMaterial> ObraMateriales { get; set; } = [];
    public IEnumerable<MovimientoFin> Movimientos { get; set; } = [];
    public decimal TotalIngresosObra { get; set; }
    public decimal TotalEgresosObra { get; set; }
    public decimal BalanceObra => TotalIngresosObra - TotalEgresosObra;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        var obra = await _obraService.ObtenerPorIdAsync(id);
        if (obra == null) return NotFound();

        Obra = obra;
        Asignaciones = await _asignacionService.ObtenerPorObraAsync(id);
        ObraMateriales = await _obraMaterialService.ObtenerPorObraAsync(id);
        Movimientos = await _movimientoFinService.ObtenerPorObraAsync(id);
        (TotalIngresosObra, TotalEgresosObra) = await _movimientoFinService.ObtenerResumenPorObraAsync(id);
        return Page();
    }
}
