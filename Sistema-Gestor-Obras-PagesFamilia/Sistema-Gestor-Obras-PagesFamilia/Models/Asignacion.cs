using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Asignacion
{
    public int IdAsignacion { get; set; }

    public int IdEmpleado { get; set; }

    public int IdObra { get; set; }

    public string? Tarea { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Obra IdObraNavigation { get; set; } = null!;

    public virtual ICollection<RegistroHora> RegistroHoras { get; set; } = new List<RegistroHora>();
}
