using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(PagesFamiliaContext context) : base(context) { }

    public async Task<Usuario?> GetByEmailAsync(string email) =>
        await Context.Usuarios
            .Include(u => u.IdRols)
            .FirstOrDefaultAsync(u => u.Email == email && u.Activo == true);

    public async Task<Usuario?> GetByIdWithRolesAsync(int id) =>
        await Context.Usuarios
            .Include(u => u.IdRols)
            .FirstOrDefaultAsync(u => u.IdUsuario == id);

    public async Task<IEnumerable<Usuario>> GetAllWithRolesAsync() =>
        await Context.Usuarios
            .Include(u => u.IdRols)
            .OrderBy(u => u.Email)
            .ToListAsync();
}
