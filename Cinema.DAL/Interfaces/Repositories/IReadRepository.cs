using Ardalis.Specification;

namespace Cinema.DAL.Interfaces.Repositories;

public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity>
    where TEntity : class
{

}