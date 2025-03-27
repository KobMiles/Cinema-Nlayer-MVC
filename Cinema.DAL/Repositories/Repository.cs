using Cinema.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Cinema.DAL.Interfaces.Repositories;
using Ardalis.Specification.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class Repository<TEntity>(DbContext context)
    : RepositoryBase<TEntity>(context), IRepository<TEntity>
    where TEntity : class, IEntity
{

}