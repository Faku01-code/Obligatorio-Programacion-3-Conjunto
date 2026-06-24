using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<IEnumerable<Cliente>> GetAllActiveAsync() =>
        await Context.Clientes
            .Where(c => c.Activo == true)
            .OrderBy(c => c.Nombre)
            .ToListAsync();
}
