using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface ICompraRepository : IRepository<Compra>
{
    Task<Compra?> GetByIdWithDetailsAsync(int id);
}
