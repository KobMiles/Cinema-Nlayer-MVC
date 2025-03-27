using Cinema.DAL.Entities;

namespace Cinema.DAL.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<Movie> Movies { get; }
    IRepository<Genre> Genres { get; }
    IRepository<Hall> Halls { get; }
    IRepository<Session> Sessions { get; }
    IRepository<Seat> Seats { get; }
    IRepository<Ticket> Tickets { get; }
    IRepository<Payment> Payments { get; }
    IUserRepository Users { get; }

    int Save();
    Task<int> SaveAsync();
}