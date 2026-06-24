using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Clientes;

public class EditModel : AuthenticatedPageModel
{
    private readonly IClienteService _clienteService;

    public EditModel(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [BindProperty]
    public ClienteFormViewModel Input { get; set; } = new();

    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        var cliente = await _clienteService.ObtenerPorIdAsync(id);
        if (cliente == null) return NotFound();

        Input = new ClienteFormViewModel
        {
            IdCliente = cliente.IdCliente,
            Nombre = cliente.Nombre,
            Telefono = cliente.Telefono,
            Email = cliente.Email
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        if (!ModelState.IsValid) return Page();

        var (success, error) = await _clienteService.ActualizarAsync(new Cliente
        {
            IdCliente = Input.IdCliente,
            Nombre = Input.Nombre.Trim(),
            Telefono = Input.Telefono?.Trim(),
            Email = Input.Email?.Trim()
        });

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Cliente actualizado.";
        return RedirectToPage("Index");
    }
}
