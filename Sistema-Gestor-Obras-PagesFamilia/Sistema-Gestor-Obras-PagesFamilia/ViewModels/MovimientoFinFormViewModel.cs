using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class MovimientoFinFormViewModel
{
    [Required(ErrorMessage = "Seleccione una obra.")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una obra.")]
    public int IdObra { get; set; }

    [Required(ErrorMessage = "Seleccione una categoría.")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una categoría.")]
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "El monto es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "La fecha es requerida.")]
    public DateOnly Fecha { get; set; }

    [MaxLength(255)]
    public string? Descripcion { get; set; }
}
