using Ardalis.Specification;
using Cinema.DAL.Entities;

namespace Cinema.DAL.Interfaces.Repositories;

public interface IUserRepository
    : IRepositoryBase<User>, IReadRepository<User>
{
}