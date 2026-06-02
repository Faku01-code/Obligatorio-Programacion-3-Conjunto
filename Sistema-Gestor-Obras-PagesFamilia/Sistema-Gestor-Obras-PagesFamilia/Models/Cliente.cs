using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
