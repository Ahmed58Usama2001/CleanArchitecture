using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private ApplicationDbContext _context = null;
    private DbSet<TEntity> _entity;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entity=_context.Set<TEntity>();
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        await _entity.AddAsync(entity);
        
        return entity;
    }

    public async ValueTask<TEntity> Read(string entityId)=> await _entity.FindAsync(entityId);

    public async ValueTask<IEnumerable<TEntity>> ReadAll()=> await _entity.ToListAsync();

    public void UpdateAsync(TEntity entity)
    {
        _entity.Attach(entity);
        _entity.Update(entity);
    }

    public async ValueTask DeleteAsync(string entityId)
    {
        var objectData= await _entity.FindAsync(entityId);

        if (objectData != null) 
            _entity.Remove(objectData);
    }

    public int SaveChanges()=> _context.SaveChanges();
}
