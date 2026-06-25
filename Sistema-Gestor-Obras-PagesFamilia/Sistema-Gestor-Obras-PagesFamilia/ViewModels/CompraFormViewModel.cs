using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class CompraFormViewModel
{
    [Required]
    public int IdObraMaterial { get; set; }

    [Required(ErrorMessage = "La cantidad es obligatoria.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero.")]
    public decimal Cantidad { get; set; }

    [Required(ErrorMessage = "El costo unitario es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El costo unitario no puede ser negativo.")]
    public decimal CostoUnitario { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateOnly Fecha { get; set; }

    [MaxLength(255)]
    public string? Descripcion { get; set; }
}
