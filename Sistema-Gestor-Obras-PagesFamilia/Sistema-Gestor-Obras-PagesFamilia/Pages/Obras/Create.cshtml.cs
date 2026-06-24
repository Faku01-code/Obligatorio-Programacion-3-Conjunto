using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;
    private readonly IClienteService _clienteService;
    private readonly IEstadoObraService _estadoObraService;

    public CreateModel(
        IObraService obraService,
        IClienteService clienteService,
        IEstadoObraService estadoObraService)
    {
        _obraService = obraService;
        _clienteService = clienteService;
        _estadoObraService = estadoObraService;
    }

    [BindProperty]
    public ObraFormViewModel Input { get; set; } = new();

    public SelectList Clientes { get; set; } = null!;
    public SelectList Estados { get; set; } = null!;
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        await CargarSelectsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        await CargarSelectsAsync();

        if (!ModelState.IsValid)
            return Page();

        var obra = MapToEntity(Input);
        var (success, error) = await _obraService.CrearAsync(obra, UsuarioId);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Obra creada correctamente.";
        return RedirectToPage("Index");
    }

    private async Task CargarSelectsAsync()
    {
        var clientes = await _clienteService.ObtenerActivosAsync();
        var estados = await _estadoObraService.ObtenerTodosAsync();

        Clientes = new SelectList(clientes, "IdCliente", "Nombre", Input.IdCliente);
        Estados = new SelectList(estados, "IdEstado", "Nombre", Input.IdEstado);
    }

    private static Obra MapToEntity(ObraFormViewModel vm) => new()
    {
        Nombre = vm.Nombre.Trim(),
        Direccion = vm.Direccion?.Trim(),
        Descripcion = vm.Descripcion?.Trim(),
        FechaInicio = vm.FechaInicio,
        FechaFinEstimada = vm.FechaFinEstimada,
        IdCliente = vm.IdCliente,
        IdEstado = vm.IdEstado
    };
}
