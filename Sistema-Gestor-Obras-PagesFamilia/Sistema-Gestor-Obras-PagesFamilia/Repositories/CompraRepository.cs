using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class CompraRepository : Repository<Compra>, ICompraRepository
{
    public CompraRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<Compra?> GetByIdWithDetailsAsync(int id) =>
        await Context.Compras
            .Include(c => c.IdObraMaterialNavigation)
                .ThenInclude(om => om.IdMaterialNavigation)
            .Include(c => c.IdObraMaterialNavigation)
                .ThenInclude(om => om.IdObraNavigation)
            .Include(c => c.IdMovimientoNavigation)
            .FirstOrDefaultAsync(c => c.IdCompra == id);
}
