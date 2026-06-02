using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Obra
{
    public int IdObra { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFinEstimada { get; set; }

    public int IdCliente { get; set; }

    public int IdEstado { get; set; }

    public bool? Activo { get; set; }

    public DateOnly? FechaBaja { get; set; }

    public int? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Asignacion> Asignacions { get; set; } = new List<Asignacion>();

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual EstadoObra IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<MovimientoFin> MovimientoFins { get; set; } = new List<MovimientoFin>();

    public virtual ICollection<ObraMaterial> ObraMaterials { get; set; } = new List<ObraMaterial>();
}
