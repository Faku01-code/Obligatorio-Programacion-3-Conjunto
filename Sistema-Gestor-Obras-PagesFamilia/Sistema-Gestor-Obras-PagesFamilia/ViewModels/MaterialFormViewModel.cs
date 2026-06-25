using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class MaterialFormViewModel
{
    public int IdMaterial { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(120)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La unidad es obligatoria.")]
    [MaxLength(20)]
    public string Unidad { get; set; } = string.Empty;
}
