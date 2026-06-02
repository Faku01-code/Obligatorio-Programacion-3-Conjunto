using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class CategoriaMov
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public virtual ICollection<MovimientoFin> MovimientoFins { get; set; } = new List<MovimientoFin>();
}
