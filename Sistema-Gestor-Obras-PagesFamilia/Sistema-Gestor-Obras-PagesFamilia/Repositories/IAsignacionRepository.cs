using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public interface IAsignacionRepository : IRepository<Asignacion>
{
    Task<IEnumerable<Asignacion>> GetByObraIdAsync(int obraId);
    Task<IEnumerable<Asignacion>> GetByEmpleadoIdAsync(int empleadoId);
    Task<Asignacion?> GetByIdWithDetailsAsync(int id);
    Task<bool> TieneRegistroHorasAsync(int asignacionId);
}
