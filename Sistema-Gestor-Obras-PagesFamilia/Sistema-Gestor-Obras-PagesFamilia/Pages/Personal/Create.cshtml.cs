using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Personal;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IEmpleadoService _empleadoService;
    private readonly IOficioService _oficioService;

    public CreateModel(IEmpleadoService empleadoService, IOficioService oficioService)
    {
        _empleadoService = empleadoService;
        _oficioService = oficioService;
    }

    [BindProperty]
    public EmpleadoFormViewModel Input { get; set; } = new();
    public SelectList Oficios { get; set; } = null!;
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        await CargarOficiosAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        await CargarOficiosAsync();

        if (!ModelState.IsValid) return Page();

        var empleado = MapToEntity(Input);
        var (success, error) = await _empleadoService.CrearAsync(empleado);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Empleado registrado correctamente.";
        return RedirectToPage("Index");
    }

    private async Task CargarOficiosAsync()
    {
        var oficios = await _oficioService.ObtenerTodosAsync();
        Oficios = new SelectList(oficios, "IdOficio", "Nombre", Input.IdOficio);
    }

    private static Empleado MapToEntity(EmpleadoFormViewModel vm) => new()
    {
        Nombre = vm.Nombre.Trim(),
        Documento = string.IsNullOrWhiteSpace(vm.Documento) ? null : vm.Documento.Trim(),
        Telefono = string.IsNullOrWhiteSpace(vm.Telefono) ? null : vm.Telefono.Trim(),
        Tipo = vm.Tipo,
        IdOficio = vm.IdOficio == 0 ? null : vm.IdOficio
    };
}
