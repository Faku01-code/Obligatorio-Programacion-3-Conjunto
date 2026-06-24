using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema_Gestor_Obras_PagesFamilia.Helpers;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages;

public abstract class AuthenticatedPageModel : PageModel
{
    public int UsuarioId => HttpContext.Session.GetInt32(SessionKeys.UsuarioId) ?? 0;
    public string UsuarioEmail => HttpContext.Session.GetString(SessionKeys.UsuarioEmail) ?? string.Empty;
    public string RolNombre => HttpContext.Session.GetString(SessionKeys.RolNombre) ?? string.Empty;
    public bool PuedeEscribir => Roles.PuedeEscribir(RolNombre);
    public bool EsAdministrador => Roles.EsAdministrador(RolNombre);
    public bool EsSoloLectura => Roles.EsSoloLectura(RolNombre);

    protected IActionResult? RedirectIfNotAuthenticated()
    {
        if (UsuarioId == 0)
            return RedirectToPage("/Account/Login");
        return null;
    }

    protected IActionResult? RedirectIfNotAdmin()
    {
        var auth = RedirectIfNotAuthenticated();
        if (auth != null) return auth;
        if (!EsAdministrador)
            return RedirectToPage("/Index");
        return null;
    }

    protected IActionResult? RedirectIfReadOnly()
    {
        var auth = RedirectIfNotAuthenticated();
        if (auth != null) return auth;
        if (EsSoloLectura)
            return RedirectToPage("/Index");
        return null;
    }
}
