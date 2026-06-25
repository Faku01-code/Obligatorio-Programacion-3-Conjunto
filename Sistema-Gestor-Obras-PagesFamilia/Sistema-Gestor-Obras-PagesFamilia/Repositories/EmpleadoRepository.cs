using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<Empleado>> GetAllWithDetailsAsync(bool soloActivos = true)
    {
        var query = Context.Empleados
            .Include(e => e.IdOficioNavigation)
            .AsQueryable();

        if (soloActivos)
            query = query.Where(e => e.Activo == true);

        return await query.OrderBy(e => e.Nombre).ToListAsync();
    }

    public async Task<Empleado?> GetByIdWithDetailsAsync(int id) =>
        await Context.Empleados
            .Include(e => e.IdOficioNavigation)
            .FirstOrDefaultAsync(e => e.IdEmpleado == id);

    public async Task<int> CountActivosAsync() =>
        await Context.Empleados.CountAsync(e => e.Activo == true);
}
