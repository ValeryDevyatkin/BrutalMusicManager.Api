using BrutalMusicManager.Api.Application.Repository.Base;
using BrutalMusicManager.Api.Domain.Model.Base;
using BrutalMusicManager.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BrutalMusicManager.Api.Persistence.Repository.Base;

public abstract class RepositoryBase<T> : IRepository<T> where T : ModelBase
{
    protected MusicManagerDbContext Context { get; }

    public RepositoryBase(MusicManagerDbContext context)
    {
        Context = context;
    }

    public async Task<T> CreateAsync(T item)
    {
        var createdItem = await Context.Set<T>().AddAsync(item);
        await Context.SaveChangesAsync();

        return createdItem.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await Context.Set<T>().FindAsync(id);

        if (item == null)
        {
            return false;
        }

        Context.Set<T>().Remove(item);
        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T item)
    {
        Context.Entry(item).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}