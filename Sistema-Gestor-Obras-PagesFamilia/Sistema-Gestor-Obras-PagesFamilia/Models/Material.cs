using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string Nombre { get; set; } = null!;

    public string Unidad { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<ObraMaterial> ObraMaterials { get; set; } = new List<ObraMaterial>();
}
