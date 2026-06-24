using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages;

public class IndexModel : PageModel
{
    private readonly IObraRepository _obraRepository;
    private readonly IClienteRepository _clienteRepository;

    public IndexModel(IObraRepository obraRepository, IClienteRepository clienteRepository)
    {
        _obraRepository = obraRepository;
        _clienteRepository = clienteRepository;
    }

    public DashboardViewModel Dashboard { get; set; } = new();
    public string NombreUsuario { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Session.GetInt32("UsuarioId") == null)
            return RedirectToPage("/Account/Login");

        NombreUsuario = HttpContext.Session.GetString("UsuarioNombre") ?? "Usuario";

        var obras = (await _obraRepository.GetAllWithDetailsAsync()).ToList();

        Dashboard = new DashboardViewModel
        {
            TotalObrasActivas = obras.Count,
            TotalClientes = (await _clienteRepository.GetAllActiveAsync()).Count(),
            ObrasRecientes = obras.Take(5).Select(o => new ObraResumenViewModel
            {
                IdObra = o.IdObra, Nombre = o.Nombre,
                ClienteNombre = o.IdClienteNavigation?.Nombre,
                EstadoNombre = o.IdEstadoNavigation?.Nombre ?? "Sin estado",
                FechaInicio = o.FechaInicio
            }).ToList()
        };

        return Page();
    }
}
