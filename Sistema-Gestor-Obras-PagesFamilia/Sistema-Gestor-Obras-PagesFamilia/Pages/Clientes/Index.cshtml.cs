using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Clientes;

public class IndexModel : AuthenticatedPageModel
{
    private readonly IClienteService _clienteService;

    public IndexModel(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public IList<Cliente> Clientes { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;

        Clientes = (await _clienteService.ObtenerTodosAsync()).ToList();
        return Page();
    }
}
