using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales;

public class EditModel : AuthenticatedPageModel
{
    private readonly IMaterialService _materialService;

    public EditModel(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [BindProperty]
    public MaterialFormViewModel Input { get; set; } = new();
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var material = await _materialService.ObtenerPorIdAsync(id);
        if (material == null) return NotFound();

        Input = new MaterialFormViewModel
        {
            IdMaterial = material.IdMaterial,
            Nombre = material.Nombre,
            Unidad = material.Unidad
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        if (!ModelState.IsValid) return Page();

        var material = new Material
        {
            IdMaterial = Input.IdMaterial,
            Nombre = Input.Nombre.Trim(),
            Unidad = Input.Unidad.Trim()
        };

        var (success, error) = await _materialService.ActualizarAsync(material);

        if (!success)
        {
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Material actualizado correctamente.";
        return RedirectToPage("Index");
    }
}
