using Ardalis.Specification;
using System.Linq.Expressions;

namespace Cinema.DAL.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> GetAll();
    TEntity? GetById(int id);
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
    void Delete(TEntity entity);

    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
}
