using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IObraMaterialRepository : IRepository<ObraMaterial>
{
    Task<IEnumerable<ObraMaterial>> GetByObraIdAsync(int obraId);
    Task<IEnumerable<ObraMaterial>> GetByMaterialIdAsync(int materialId);
    Task<ObraMaterial?> GetByIdWithDetailsAsync(int id);
    Task<bool> ExisteAsync(int obraId, int materialId);
    Task<bool> TieneComprasAsync(int obraMaterialId);
}
