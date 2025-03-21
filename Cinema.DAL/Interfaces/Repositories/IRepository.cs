using Ardalis.Specification;

namespace Cinema.DAL.Interfaces.Repositories;

public interface IRepository<TEntity> : IRepositoryBase<TEntity>, IReadRepository<TEntity>
    where TEntity : class
{

}