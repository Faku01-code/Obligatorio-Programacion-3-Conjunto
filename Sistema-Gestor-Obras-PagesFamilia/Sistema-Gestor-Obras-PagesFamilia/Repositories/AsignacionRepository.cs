using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class AsignacionRepository : Repository<Asignacion>, IAsignacionRepository
{
    public AsignacionRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<Asignacion>> GetByObraIdAsync(int obraId) =>
        await Context.Asignacions
            .Include(a => a.IdEmpleadoNavigation)
                .ThenInclude(e => e.IdOficioNavigation)
            .Where(a => a.IdObra == obraId)
            .OrderBy(a => a.FechaInicio)
            .ToListAsync();

    public async Task<IEnumerable<Asignacion>> GetByEmpleadoIdAsync(int empleadoId) =>
        await Context.Asignacions
            .Include(a => a.IdObraNavigation)
            .Where(a => a.IdEmpleado == empleadoId)
            .OrderByDescending(a => a.FechaInicio)
            .ToListAsync();

    public async Task<Asignacion?> GetByIdWithDetailsAsync(int id) =>
        await Context.Asignacions
            .Include(a => a.IdEmpleadoNavigation)
                .ThenInclude(e => e.IdOficioNavigation)
            .Include(a => a.IdObraNavigation)
            .FirstOrDefaultAsync(a => a.IdAsignacion == id);

    public async Task<bool> TieneRegistroHorasAsync(int asignacionId) =>
        await Context.RegistroHoras.AnyAsync(r => r.IdAsignacion == asignacionId);
}
