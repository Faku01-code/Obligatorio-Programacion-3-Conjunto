using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class ObraMaterialRepository : Repository<ObraMaterial>, IObraMaterialRepository
{
    public ObraMaterialRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<ObraMaterial>> GetByObraIdAsync(int obraId) =>
        await Context.ObraMaterials
            .Include(om => om.IdMaterialNavigation)
            .Include(om => om.Compras)
                .ThenInclude(c => c.IdMovimientoNavigation)
            .Where(om => om.IdObra == obraId)
            .OrderBy(om => om.IdMaterialNavigation.Nombre)
            .ToListAsync();

    public async Task<IEnumerable<ObraMaterial>> GetByMaterialIdAsync(int materialId) =>
        await Context.ObraMaterials
            .Include(om => om.IdObraNavigation)
            .Include(om => om.Compras)
            .Where(om => om.IdMaterial == materialId)
            .OrderBy(om => om.IdObraNavigation.Nombre)
            .ToListAsync();

    public async Task<ObraMaterial?> GetByIdWithDetailsAsync(int id) =>
        await Context.ObraMaterials
            .Include(om => om.IdMaterialNavigation)
            .Include(om => om.IdObraNavigation)
            .Include(om => om.Compras)
                .ThenInclude(c => c.IdMovimientoNavigation)
            .FirstOrDefaultAsync(om => om.IdObraMaterial == id);

    public async Task<bool> ExisteAsync(int obraId, int materialId) =>
        await Context.ObraMaterials.AnyAsync(om => om.IdObra == obraId && om.IdMaterial == materialId);

    public async Task<bool> TieneComprasAsync(int obraMaterialId) =>
        await Context.Compras.AnyAsync(c => c.IdObraMaterial == obraMaterialId);
}
