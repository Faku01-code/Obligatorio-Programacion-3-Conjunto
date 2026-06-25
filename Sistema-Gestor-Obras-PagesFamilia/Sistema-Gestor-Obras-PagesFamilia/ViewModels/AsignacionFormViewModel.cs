using System.ComponentModel.DataAnnotations;

namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class AsignacionFormViewModel
{
    [Required(ErrorMessage = "Seleccione un empleado.")]
    public int IdEmpleado { get; set; }

    [Required(ErrorMessage = "Seleccione una obra.")]
    public int IdObra { get; set; }

    [MaxLength(150)]
    public string? Tarea { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }
}
