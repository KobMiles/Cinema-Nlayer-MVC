using Cinema.DAL.Data;
using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces.Repositories;

namespace Cinema.DAL.Repositories;

public class UnitOfWork(CinemaDbContext context) : IUnitOfWork
{

    private IRepository<Movie>? _movies;
    private IRepository<Genre>? _genres;
    private IRepository<Hall>? _halls;
    private IRepository<Session>? _sessions;
    private IRepository<Seat>? _seats;
    private IRepository<Ticket>? _tickets;
    private IRepository<Payment>? _payments;
    private IUserRepository? _users;

    public IRepository<Movie> Movies
        => _movies ??= new Repository<Movie>(context);

    public IRepository<Genre> Genres
        => _genres ??= new Repository<Genre>(context);

    public IRepository<Hall> Halls
        => _halls ??= new Repository<Hall>(context);

    public IRepository<Session> Sessions
        => _sessions ??= new Repository<Session>(context);

    public IRepository<Seat> Seats
        => _seats ??= new Repository<Seat>(context);

    public IRepository<Ticket> Tickets
        => _tickets ??= new Repository<Ticket>(context);

    public IRepository<Payment> Payments
        => _payments ??= new Repository<Payment>(context);
    public IUserRepository Users
        => _users ??= new UserRepository(context);

    public int Save() => context.SaveChanges();
    public async Task<int> SaveAsync() => await context.SaveChangesAsync();

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}