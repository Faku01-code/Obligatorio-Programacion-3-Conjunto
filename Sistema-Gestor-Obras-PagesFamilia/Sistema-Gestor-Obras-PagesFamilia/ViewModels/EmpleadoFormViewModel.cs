using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class EmpleadoFormViewModel
{
    public int IdEmpleado { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(120)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Documento { get; set; }

    [MaxLength(30)]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El tipo es obligatorio.")]
    public string Tipo { get; set; } = "FIJO";

    public int? IdOficio { get; set; }
}
