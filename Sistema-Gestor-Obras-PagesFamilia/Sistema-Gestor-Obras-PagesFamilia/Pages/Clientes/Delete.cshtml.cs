using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Clientes;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IClienteService _clienteService;

    public DeleteModel(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [BindProperty]
    public Cliente Cliente { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var cliente = await _clienteService.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound();
        Cliente = cliente;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var (success, error) = await _clienteService.DarDeBajaAsync(Cliente.IdCliente);
        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Cliente dado de baja.";
        return RedirectToPage("Index");
    }
}
