using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class ObraFormViewModel
{
    public int IdObra { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Direccion { get; set; }

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Display(Name = "Fecha inicio")]
    [DataType(DataType.Date)]
    public DateOnly? FechaInicio { get; set; }

    [Display(Name = "Fecha fin estimada")]
    [DataType(DataType.Date)]
    public DateOnly? FechaFinEstimada { get; set; }

    [Required(ErrorMessage = "Seleccione un cliente")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente")]
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "Seleccione un estado")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un estado")]
    public int IdEstado { get; set; }
}
