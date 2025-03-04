using Cinema.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Cinema.DAL.Interfaces.Repositories;
using Ardalis.Specification.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
        : base(context)
    {
        _dbSet = context.Set<TEntity>();
    }
}