using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras;

public class EditModel : AuthenticatedPageModel
{
    private readonly IObraService _obraService;
    private readonly IClienteService _clienteService;
    private readonly IEstadoObraService _estadoObraService;

    public EditModel(
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

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var obra = await _obraService.ObtenerPorIdAsync(id);
        if (obra == null) return NotFound();

        Input = new ObraFormViewModel
        {
            IdObra = obra.IdObra,
            Nombre = obra.Nombre,
            Direccion = obra.Direccion,
            Descripcion = obra.Descripcion,
            FechaInicio = obra.FechaInicio,
            FechaFinEstimada = obra.FechaFinEstimada,
            IdCliente = obra.IdCliente,
            IdEstado = obra.IdEstado
        };

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

        var obra = new Obra
        {
            IdObra = Input.IdObra,
            Nombre = Input.Nombre.Trim(),
            Direccion = Input.Direccion?.Trim(),
            Descripcion = Input.Descripcion?.Trim(),
            FechaInicio = Input.FechaInicio,
            FechaFinEstimada = Input.FechaFinEstimada,
            IdCliente = Input.IdCliente,
            IdEstado = Input.IdEstado
        };

        var (success, error) = await _obraService.ActualizarAsync(obra);
        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Obra actualizada correctamente.";
        return RedirectToPage("Details", new { id = Input.IdObra });
    }

    private async Task CargarSelectsAsync()
    {
        var clientes = await _clienteService.ObtenerActivosAsync();
        var estados = await _estadoObraService.ObtenerTodosAsync();
        Clientes = new SelectList(clientes, "IdCliente", "Nombre", Input.IdCliente);
        Estados = new SelectList(estados, "IdEstado", "Nombre", Input.IdEstado);
    }
}
