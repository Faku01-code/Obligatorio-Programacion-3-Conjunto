namespace Sistema_Gestor_Obras_PagesFamilia.ViewModels;

public class DashboardViewModel
{
    public int TotalObrasActivas { get; set; }
    public int TotalClientes { get; set; }
    public int TotalEmpleados { get; set; }
    public List<ObraResumenViewModel> ObrasRecientes { get; set; } = [];
}

public class ObraResumenViewModel
{
    public int IdObra { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? ClienteNombre { get; set; }
    public string EstadoNombre { get; set; } = string.Empty;
    public DateOnly? FechaInicio { get; set; }
}
