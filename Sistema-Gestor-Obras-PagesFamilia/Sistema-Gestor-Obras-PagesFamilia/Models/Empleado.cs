using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Documento { get; set; }

    public string? Telefono { get; set; }

    public string Tipo { get; set; } = null!;

    public int? IdOficio { get; set; }

    public bool? Activo { get; set; }

    public DateOnly? FechaBaja { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual Oficio? IdOficioNavigation { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
