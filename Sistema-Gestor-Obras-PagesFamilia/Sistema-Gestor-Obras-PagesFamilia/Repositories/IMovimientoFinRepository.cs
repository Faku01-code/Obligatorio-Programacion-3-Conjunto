using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IMovimientoFinRepository : IRepository<MovimientoFin>
{
    Task<IEnumerable<MovimientoFin>> GetAllWithDetailsAsync();
    Task<IEnumerable<MovimientoFin>> GetByObraIdAsync(int obraId);
    Task<MovimientoFin?> GetByIdWithDetailsAsync(int id);
}
