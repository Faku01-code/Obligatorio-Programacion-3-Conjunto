using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class OficioRepository : Repository<Oficio>, IOficioRepository
{
    public OficioRepository(PagesFamiliaContext context) : base(context) { }

    public override async Task<IEnumerable<Oficio>> GetAllAsync() =>
        await Context.Oficios.OrderBy(o => o.Nombre).ToListAsync();
}
