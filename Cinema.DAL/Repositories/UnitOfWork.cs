using Cinema.DAL.Data;
using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces.Repositories;

namespace Cinema.DAL.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly CinemaDbContext _context;

    private IRepository<Movie>? _movies;
    private IRepository<Genre>? _genres;
    private IRepository<Hall>? _halls;
    private IRepository<Session>? _sessions;
    private IRepository<Seat>? _seats;
    private IRepository<Ticket>? _tickets;
    private IRepository<Payment>? _payments;

    public UnitOfWork(CinemaDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IRepository<Movie> Movies
        => _movies ??= new Repository<Movie>(_context);

    public IRepository<Genre> Genres
        => _genres ??= new Repository<Genre>(_context);

    public IRepository<Hall> Halls
        => _halls ??= new Repository<Hall>(_context);

    public IRepository<Session> Sessions
        => _sessions ??= new Repository<Session>(_context);

    public IRepository<Seat> Seats
        => _seats ??= new Repository<Seat>(_context);

    public IRepository<Ticket> Tickets
        => _tickets ??= new Repository<Ticket>(_context);

    public IRepository<Payment> Payments
        => _payments ??= new Repository<Payment>(_context);

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    #region IDisposable
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
