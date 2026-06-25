using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Personal.Asignaciones;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IAsignacionService _asignacionService;
    private readonly IEmpleadoService _empleadoService;
    private readonly IObraService _obraService;

    public CreateModel(
        IAsignacionService asignacionService,
        IEmpleadoService empleadoService,
        IObraService obraService)
    {
        _asignacionService = asignacionService;
        _empleadoService = empleadoService;
        _obraService = obraService;
    }

    [BindProperty]
    public AsignacionFormViewModel Input { get; set; } = new();
    public SelectList Empleados { get; set; } = null!;
    public SelectList Obras { get; set; } = null!;
    public string? ErrorMessage { get; set; }
    public int? ReturnEmpleadoId { get; set; }
    public int? ReturnObraId { get; set; }

    public async Task<IActionResult> OnGetAsync(int? empleadoId, int? obraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        ReturnEmpleadoId = empleadoId;
        ReturnObraId = obraId;

        if (empleadoId.HasValue) Input.IdEmpleado = empleadoId.Value;
        if (obraId.HasValue) Input.IdObra = obraId.Value;
        Input.FechaInicio = DateOnly.FromDateTime(DateTime.Today);

        await CargarSelectsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? returnEmpleadoId, int? returnObraId)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        await CargarSelectsAsync();

        if (!ModelState.IsValid) return Page();

        var asignacion = MapToEntity(Input);
        var (success, error) = await _asignacionService.CrearAsync(asignacion, UsuarioId);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Asignación registrada correctamente.";

        if (returnEmpleadoId.HasValue)
            return RedirectToPage("/Personal/Details", new { id = returnEmpleadoId });
        if (returnObraId.HasValue)
            return RedirectToPage("/Obras/Details", new { id = returnObraId });

        return RedirectToPage("/Personal/Index");
    }

    private async Task CargarSelectsAsync()
    {
        var empleados = await _empleadoService.ObtenerTodosAsync(soloActivos: true);
        var obras = await _obraService.ObtenerTodasAsync(soloActivas: true);

        Empleados = new SelectList(empleados, "IdEmpleado", "Nombre", Input.IdEmpleado);
        Obras = new SelectList(obras, "IdObra", "Nombre", Input.IdObra);
    }

    private static Asignacion MapToEntity(AsignacionFormViewModel vm) => new()
    {
        IdEmpleado = vm.IdEmpleado,
        IdObra = vm.IdObra,
        Tarea = string.IsNullOrWhiteSpace(vm.Tarea) ? null : vm.Tarea.Trim(),
        FechaInicio = vm.FechaInicio,
        FechaFin = vm.FechaFin
    };
}
