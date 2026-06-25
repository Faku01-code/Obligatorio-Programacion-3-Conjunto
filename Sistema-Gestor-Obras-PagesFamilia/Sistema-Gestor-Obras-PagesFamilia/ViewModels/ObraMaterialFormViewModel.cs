using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class ObraMaterialFormViewModel
{
    [Required]
    public int IdObra { get; set; }

    [Required(ErrorMessage = "Seleccioná un material.")]
    public int IdMaterial { get; set; }

    [Required(ErrorMessage = "La cantidad requerida es obligatoria.")]
    [Range(0, double.MaxValue, ErrorMessage = "La cantidad no puede ser negativa.")]
    public decimal CantRequerida { get; set; }
}
