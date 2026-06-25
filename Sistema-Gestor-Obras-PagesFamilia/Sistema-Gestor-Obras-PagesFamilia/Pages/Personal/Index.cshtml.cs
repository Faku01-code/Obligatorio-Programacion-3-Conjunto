using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Personal;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IEmpleadoService _empleadoService;

    public IndexModel(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    public IEnumerable<Empleado> Empleados { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        Empleados = await _empleadoService.ObtenerTodosAsync(soloActivos: !EsAdministrador);
        return Page();
    }
}
