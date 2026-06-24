using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Contrasenia { get; set; } = string.Empty;

    [Required(ErrorMessage = "Seleccione un rol")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un rol")]
    public int IdRol { get; set; }
}

public class RolLoginOption
{
    public int IdRol { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
}
