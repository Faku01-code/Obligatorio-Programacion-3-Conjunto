using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;
    private readonly IClienteService _clienteService;
    private readonly IRepository<Empleado> _empleadoRepository;

    public IndexModel(
        IObraService obraService,
        IClienteService clienteService,
        IRepository<Empleado> empleadoRepository)
    {
        _obraService = obraService;
        _clienteService = clienteService;
        _empleadoRepository = empleadoRepository;
    }

    public DashboardViewModel Dashboard { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        var obras = (await _obraService.ObtenerTodasAsync()).ToList();
        var empleados = (await _empleadoRepository.GetAllAsync()).ToList();

        Dashboard = new DashboardViewModel
        {
            TotalObrasActivas = obras.Count,
            TotalClientes = (await _clienteService.ObtenerActivosAsync()).Count(),
            TotalEmpleados = empleados.Count(e => e.Activo == true),
            ObrasRecientes = obras.Take(5).Select(o => new ObraResumenViewModel
            {
                IdObra = o.IdObra,
                Nombre = o.Nombre,
                ClienteNombre = o.IdClienteNavigation?.Nombre,
                EstadoNombre = o.IdEstadoNavigation?.Nombre ?? "Sin estado",
                FechaInicio = o.FechaInicio
            }).ToList()
        };

        return Page();
    }
}
