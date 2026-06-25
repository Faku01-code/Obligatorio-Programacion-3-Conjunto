using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IMaterialRepository : IRepository<Material>
{
    Task<IEnumerable<Material>> GetAllAsync(bool soloActivos = true);
    Task<Material?> GetByIdWithDetailsAsync(int id);
}
