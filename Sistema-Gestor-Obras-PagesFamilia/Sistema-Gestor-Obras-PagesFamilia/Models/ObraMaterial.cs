using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class ObraMaterial
{
    public int IdObraMaterial { get; set; }

    public int IdObra { get; set; }

    public int IdMaterial { get; set; }

    public decimal CantRequerida { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Material IdMaterialNavigation { get; set; } = null!;

    public virtual Obra IdObraNavigation { get; set; } = null!;
}
