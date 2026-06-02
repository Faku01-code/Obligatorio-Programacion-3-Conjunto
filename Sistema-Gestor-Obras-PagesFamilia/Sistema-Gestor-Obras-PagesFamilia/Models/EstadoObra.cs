using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class EstadoObra
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Orden { get; set; }

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
