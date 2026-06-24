using Microsoft.EntityFrameworkCore;

namespace Sistema_Gestor_Obras_PagesFamilia.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
