using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class UsuarioFormViewModel
{
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress]
    [StringLength(120)]
    public string Email { get; set; } = string.Empty;

    [StringLength(255)]
    public string Contrasenia { get; set; } = string.Empty;

    public bool CambiarContrasenia { get; set; }

    public List<int> RolesSeleccionados { get; set; } = [];
}
