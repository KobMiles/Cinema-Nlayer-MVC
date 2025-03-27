using Ardalis.Specification.EntityFrameworkCore;
using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class UserRepository(DbContext context)
    : RepositoryBase<User>(context), IUserRepository
{

}