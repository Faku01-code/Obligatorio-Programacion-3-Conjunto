using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Finanzas;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IMovimientoFinService _movimientoFinService;
    private readonly IObraService _obraService;
    private readonly IRepository<CategoriaMov> _categoriaRepository;

    public CreateModel(
        IMovimientoFinService movimientoFinService,
        IObraService obraService,
        IRepository<CategoriaMov> categoriaRepository)
    {
        _movimientoFinService = movimientoFinService;
        _obraService = obraService;
        _categoriaRepository = categoriaRepository;
    }

    [BindProperty]
    public MovimientoFinFormViewModel Input { get; set; } = new();

    public SelectList ObrasSelect { get; set; } = null!;
    public IEnumerable<CategoriaMov> Categorias { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(int? obraId = null)
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;
        if (EsSoloLectura) return RedirectToPage("/Index");

        Input.Fecha = DateOnly.FromDateTime(DateTime.Today);
        if (obraId.HasValue) Input.IdObra = obraId.Value;

        await CargarSelectsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfNotAuthenticated();
        if (redirect != null) return redirect;
        if (EsSoloLectura) return RedirectToPage("/Index");

        if (!ModelState.IsValid)
        {
            await CargarSelectsAsync();
            return Page();
        }

        var (ok, error) = await _movimientoFinService.CrearAsync(Input, UsuarioId);
        if (!ok)
        {
            ModelState.AddModelError(string.Empty, error ?? "Error al registrar el movimiento.");
            await CargarSelectsAsync();
            return Page();
        }

        TempData["Success"] = "Movimiento registrado correctamente.";
        return RedirectToPage("/Finanzas/Index");
    }

    private async Task CargarSelectsAsync()
    {
        var obras = await _obraService.ObtenerTodasAsync();
        ObrasSelect = new SelectList(obras, "IdObra", "Nombre", Input.IdObra);
        Categorias = await _categoriaRepository.GetAllAsync();
    }
}
