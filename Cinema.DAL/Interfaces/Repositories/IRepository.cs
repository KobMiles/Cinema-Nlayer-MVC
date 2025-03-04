using Ardalis.Specification;
using System.Linq.Expressions;

namespace Cinema.DAL.Interfaces.Repositories;

public interface IRepository<TEntity> : IRepositoryBase<TEntity>, IReadRepository<TEntity>
    where TEntity : class, IEntity
{
}