using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Personal;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly IEmpleadoService _empleadoService;
    private readonly IAsignacionService _asignacionService;

    public DetailsModel(IEmpleadoService empleadoService, IAsignacionService asignacionService)
    {
        _empleadoService = empleadoService;
        _asignacionService = asignacionService;
    }

    public Empleado Empleado { get; set; } = null!;
    public IEnumerable<Asignacion> Asignaciones { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        var empleado = await _empleadoService.ObtenerPorIdAsync(id);
        if (empleado == null) return NotFound();

        Empleado = empleado;
        Asignaciones = await _asignacionService.ObtenerPorEmpleadoAsync(id);
        return Page();
    }
}
