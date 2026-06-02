using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class MovimientoFin
{
    public int IdMovimiento { get; set; }

    public int IdObra { get; set; }

    public int IdCategoria { get; set; }

    public decimal Monto { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Descripcion { get; set; }

    public int? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Compra? Compra { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual CategoriaMov IdCategoriaNavigation { get; set; } = null!;

    public virtual Obra IdObraNavigation { get; set; } = null!;
}
