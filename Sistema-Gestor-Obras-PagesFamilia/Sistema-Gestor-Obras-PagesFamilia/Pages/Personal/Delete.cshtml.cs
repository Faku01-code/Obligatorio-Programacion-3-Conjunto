using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Personal;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IEmpleadoService _empleadoService;

    public DeleteModel(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    [BindProperty]
    public Empleado Empleado { get; set; } = null!;
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var empleado = await _empleadoService.ObtenerPorIdAsync(id);
        if (empleado == null) return NotFound();

        Empleado = empleado;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var (success, error) = await _empleadoService.DarDeBajaAsync(Empleado.IdEmpleado);

        if (!success)
        {
            ErrorMessage = error;
            var empleado = await _empleadoService.ObtenerPorIdAsync(Empleado.IdEmpleado);
            if (empleado != null) Empleado = empleado;
            return Page();
        }

        TempData["Success"] = "Empleado dado de baja correctamente.";
        return RedirectToPage("Index");
    }
}
