using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales;

public class CreateModel : AuthenticatedPageModel
{
    private readonly IMaterialService _materialService;

    public CreateModel(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [BindProperty]
    public MaterialFormViewModel Input { get; set; } = new();
    public string? ErrorMessage { get; set; }

    public IActionResult OnGet()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        if (!ModelState.IsValid) return Page();

        var material = new Material
        {
            Nombre = Input.Nombre.Trim(),
            Unidad = Input.Unidad.Trim()
        };

        var (success, error) = await _materialService.CrearAsync(material);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Material creado correctamente.";
        return RedirectToPage("Index");
    }
}
