using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;

namespace Sistema_Gestor_Obras_PagesFamilia.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly PagesFamiliaContext Context;
    protected readonly DbSet<T> DbSet;

    public Repository(PagesFamiliaContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id) =>
        await DbSet.FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync() =>
        await DbSet.ToListAsync();

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
        Context.SaveChanges();
    }

    public async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
        Context.SaveChanges();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) =>
        await DbSet.AnyAsync(predicate);
}
