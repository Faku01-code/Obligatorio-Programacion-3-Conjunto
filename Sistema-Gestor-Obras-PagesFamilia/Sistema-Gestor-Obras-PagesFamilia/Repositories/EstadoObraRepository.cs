using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class EstadoObraRepository : Repository<EstadoObra>, IEstadoObraRepository
{
    public EstadoObraRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<EstadoObra>> GetAllOrderedAsync() =>
        await Context.EstadoObras
            .OrderBy(e => e.Orden)
            .ThenBy(e => e.Nombre)
            .ToListAsync();
}
