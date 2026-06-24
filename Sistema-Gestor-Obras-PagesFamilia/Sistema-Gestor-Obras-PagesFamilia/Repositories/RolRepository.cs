using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class RolRepository : Repository<Rol>, IRolRepository
{
    public RolRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<Rol?> GetByNombreAsync(string nombre) =>
        await Context.Rols.FirstOrDefaultAsync(r => r.Nombre == nombre);
}
