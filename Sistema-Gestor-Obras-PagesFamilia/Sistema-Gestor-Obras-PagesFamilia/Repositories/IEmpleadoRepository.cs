using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IEmpleadoRepository : IRepository<Empleado>
{
    Task<IEnumerable<Empleado>> GetAllWithDetailsAsync(bool soloActivos = true);
    Task<Empleado?> GetByIdWithDetailsAsync(int id);
    Task<int> CountActivosAsync();
}
