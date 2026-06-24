using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IEstadoObraRepository : IRepository<EstadoObra>
{
    Task<IEnumerable<EstadoObra>> GetAllOrderedAsync();
}
