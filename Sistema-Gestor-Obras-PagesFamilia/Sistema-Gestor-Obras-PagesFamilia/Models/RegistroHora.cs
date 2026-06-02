using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class RegistroHora
{
    public int IdRegistro { get; set; }

    public int IdAsignacion { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Horas { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Asignacion IdAsignacionNavigation { get; set; } = null!;
}
