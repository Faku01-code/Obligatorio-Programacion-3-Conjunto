using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int? IdEmpleado { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual ICollection<MovimientoFin> MovimientoFins { get; set; } = new List<MovimientoFin>();

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();

    public virtual ICollection<Rol> IdRols { get; set; } = new List<Rol>();
}
