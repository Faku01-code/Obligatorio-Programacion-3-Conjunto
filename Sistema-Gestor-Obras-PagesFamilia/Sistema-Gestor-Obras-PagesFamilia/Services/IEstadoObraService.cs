using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IEstadoObraService
{
    Task<IEnumerable<EstadoObra>> ObtenerTodosAsync();
}
