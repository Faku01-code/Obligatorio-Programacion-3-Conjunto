using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class MaterialRepository : Repository<Material>, IMaterialRepository
{
    public MaterialRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<Material>> GetAllAsync(bool soloActivos = true)
    {
        var query = Context.Materials.AsQueryable();
        if (soloActivos) query = query.Where(m => m.Activo == true);
        return await query.OrderBy(m => m.Nombre).ToListAsync();
    }

    public async Task<Material?> GetByIdWithDetailsAsync(int id) =>
        await Context.Materials
            .Include(m => m.ObraMaterials)
                .ThenInclude(om => om.IdObraNavigation)
            .FirstOrDefaultAsync(m => m.IdMaterial == id);
}
