using Microsoft.EntityFrameworkCore;
using MSK.Core.Module.Entity;

namespace MSK.Application.Module.Data
{
    public interface IEfRepositoryAsync<TEntity> : IEfRepositoryAsync<ApplicationDbContext, TEntity>
        where TEntity : IEntity
    {
    }

    public interface IEfQueryRepository<TEntity> : IEfQueryRepository<ApplicationDbContext, TEntity>
        where TEntity : IEntity
    {
    }

    public interface IEfRepositoryAsync<TDbContext, TEntity> : IRepositoryAsync<TEntity>
        where TDbContext : DbContext
        where TEntity : IEntity
    {
    }

    public interface IEfQueryRepository<TDbContext, TEntity> : IQueryRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : IEntity
    {
    }
}
