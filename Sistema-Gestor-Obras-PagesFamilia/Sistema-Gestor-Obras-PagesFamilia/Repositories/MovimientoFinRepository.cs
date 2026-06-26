using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class MovimientoFinRepository : Repository<MovimientoFin>, IMovimientoFinRepository
{
    public MovimientoFinRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<MovimientoFin>> GetAllWithDetailsAsync() =>
        await Context.MovimientoFins
            .Include(m => m.IdObraNavigation)
            .Include(m => m.IdCategoriaNavigation)
            .Include(m => m.CreadoPorNavigation)
            .Include(m => m.Compra)
            .OrderByDescending(m => m.Fecha)
            .ThenByDescending(m => m.IdMovimiento)
            .ToListAsync();

    public async Task<IEnumerable<MovimientoFin>> GetByObraIdAsync(int obraId) =>
        await Context.MovimientoFins
            .Where(m => m.IdObra == obraId)
            .Include(m => m.IdCategoriaNavigation)
            .Include(m => m.CreadoPorNavigation)
            .Include(m => m.Compra)
            .OrderByDescending(m => m.Fecha)
            .ThenByDescending(m => m.IdMovimiento)
            .ToListAsync();

    public async Task<MovimientoFin?> GetByIdWithDetailsAsync(int id) =>
        await Context.MovimientoFins
            .Include(m => m.IdObraNavigation)
            .Include(m => m.IdCategoriaNavigation)
            .Include(m => m.CreadoPorNavigation)
            .Include(m => m.Compra)
            .FirstOrDefaultAsync(m => m.IdMovimiento == id);
}
