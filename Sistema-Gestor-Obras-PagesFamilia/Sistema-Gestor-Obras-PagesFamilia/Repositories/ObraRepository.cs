using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class ObraRepository : Repository<Obra>, IObraRepository
{
    public ObraRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<Obra>> GetAllWithDetailsAsync(bool soloActivas = true)
    {
        var query = Context.Obras
            .Include(o => o.IdClienteNavigation)
            .Include(o => o.IdEstadoNavigation)
            .AsQueryable();

        if (soloActivas)
            query = query.Where(o => o.Activo == true);

        return await query
            .OrderByDescending(o => o.FechaCreacion)
            .ThenByDescending(o => o.IdObra)
            .ToListAsync();
    }

    public async Task<Obra?> GetByIdWithDetailsAsync(int id) =>
        await Context.Obras
            .Include(o => o.IdClienteNavigation)
            .Include(o => o.IdEstadoNavigation)
            .Include(o => o.CreadoPorNavigation)
            .FirstOrDefaultAsync(o => o.IdObra == id);

    public async Task<int> CountActivasAsync() =>
        await Context.Obras.CountAsync(o => o.Activo == true);
}
