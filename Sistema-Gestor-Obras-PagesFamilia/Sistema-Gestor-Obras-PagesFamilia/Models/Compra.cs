using System;
using System.Collections.Generic;

namespace Sistema_Gestor_Obras_PagesFamilia.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdObraMaterial { get; set; }

    public int IdMovimiento { get; set; }

    public decimal Cantidad { get; set; }

    public decimal CostoUnitario { get; set; }

    public DateOnly Fecha { get; set; }

    public int? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual MovimientoFin IdMovimientoNavigation { get; set; } = null!;

    public virtual ObraMaterial IdObraMaterialNavigation { get; set; } = null!;
}
