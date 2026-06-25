using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Personal.Asignaciones;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IAsignacionService _asignacionService;

    public DeleteModel(IAsignacionService asignacionService)
    {
        _asignacionService = asignacionService;
    }

    [BindProperty]
    public Asignacion Asignacion { get; set; } = null!;
    public string? ErrorMessage { get; set; }
    public int? ReturnEmpleadoId { get; set; }
    public int? ReturnObraId { get; set; }

    public async Task<IActionResult> OnGetAsync(int id, int? returnEmpleadoId, int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var asignacion = await _asignacionService.ObtenerPorIdAsync(id);
        if (asignacion == null) return NotFound();

        Asignacion = asignacion;
        ReturnEmpleadoId = returnEmpleadoId;
        ReturnObraId = returnObraId;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? returnEmpleadoId, int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var (success, error) = await _asignacionService.EliminarAsync(Asignacion.IdAsignacion);

        if (!success)
        {
            ErrorMessage = error;
            var asignacion = await _asignacionService.ObtenerPorIdAsync(Asignacion.IdAsignacion);
            if (asignacion != null) Asignacion = asignacion;
            return Page();
        }

        TempData["Success"] = "Asignación eliminada correctamente.";

        if (returnEmpleadoId.HasValue)
            return RedirectToPage("/Personal/Details", new { id = returnEmpleadoId });
        if (returnObraId.HasValue)
            return RedirectToPage("/Obras/Details", new { id = returnObraId });

        return RedirectToPage("/Personal/Index");
    }
}
