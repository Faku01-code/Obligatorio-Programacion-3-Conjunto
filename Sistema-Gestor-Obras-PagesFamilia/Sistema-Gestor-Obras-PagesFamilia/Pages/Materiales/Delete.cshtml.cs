using Microsoft.AspNetCore.Mvc;
using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Services;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Materiales;

public class DeleteModel : AuthenticatedPageModel
{
    private readonly IMaterialService _materialService;

    public DeleteModel(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    public Material Material { get; set; } = null!;
    public string? ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var material = await _materialService.ObtenerPorIdAsync(id);
        if (material == null) return NotFound();
        if (material.Activo == false) return RedirectToPage("Index");

        Material = material;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var redirect = RedirectIfReadOnly();
        if (redirect != null) return redirect;

        var (success, error) = await _materialService.DarDeBajaAsync(id);

        if (!success)
        {
            var material = await _materialService.ObtenerPorIdAsync(id);
            if (material != null) Material = material;
            ErrorMessage = error;
            return Page();
        }

        TempData["Success"] = "Material dado de baja correctamente.";
        return RedirectToPage("Index");
    }
}
