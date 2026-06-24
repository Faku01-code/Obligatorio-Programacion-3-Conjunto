using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IObraRepository : IRepository<Obra>
{
    Task<IEnumerable<Obra>> GetAllWithDetailsAsync(bool soloActivas = true);
    Task<Obra?> GetByIdWithDetailsAsync(int id);
    Task<int> CountActivasAsync();
}
