using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;
    private readonly IClienteService _clienteService;
    private readonly IEmpleadoService _empleadoService;
    private readonly IMovimientoFinService _movimientoFinService;

    public IndexModel(
        IObraService obraService,
        IClienteService clienteService,
        IEmpleadoService empleadoService,
        IMovimientoFinService movimientoFinService)
    {
        _obraService = obraService;
        _clienteService = clienteService;
        _empleadoService = empleadoService;
        _movimientoFinService = movimientoFinService;
    }

    public DashboardViewModel Dashboard { get; set; } = new();
    public decimal TotalIngresos { get; set; }
    public decimal TotalEgresos { get; set; }
    public decimal Balance => TotalIngresos - TotalEgresos;

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        var obras = (await _obraService.ObtenerTodasAsync()).ToList();

        Dashboard = new DashboardViewModel
        {
            TotalObrasActivas = obras.Count,
            TotalClientes = (await _clienteService.ObtenerActivosAsync()).Count(),
            TotalEmpleados = await _empleadoService.ContarActivosAsync(),
            ObrasRecientes = obras.Take(5).Select(o => new ObraResumenViewModel
            {
                IdObra = o.IdObra,
                Nombre = o.Nombre,
                ClienteNombre = o.IdClienteNavigation?.Nombre,
                EstadoNombre = o.IdEstadoNavigation?.Nombre ?? "Sin estado",
                FechaInicio = o.FechaInicio
            }).ToList()
        };

        (TotalIngresos, TotalEgresos) = await _movimientoFinService.ObtenerResumenGlobalAsync();
        return Page();
    }
}
