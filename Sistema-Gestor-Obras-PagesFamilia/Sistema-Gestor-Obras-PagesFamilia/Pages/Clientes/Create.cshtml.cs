using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Clientes;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IClienteService _clienteService;

    public CreateModel(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [BindProperty]
    public ClienteFormViewModel Input { get; set; } = new();

    public string? ErrorMessage { get; set; }

    public IActionResult OnGet()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAdmin();
        if (redirect != null) return redirect;

        if (!ModelState.IsValid) return Page();

        var (success, error) = await _clienteService.CrearAsync(new Cliente
        {
            Nombre = Input.Nombre.Trim(),
            Telefono = Input.Telefono?.Trim(),
            Email = Input.Email?.Trim()
        });

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Cliente creado correctamente.";
        return RedirectToPage("Index");
    }
}
