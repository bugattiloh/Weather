using Microsoft.EntityFrameworkCore;

namespace WeatherInfrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly WeatherContext _context;

    public UserRepository(WeatherContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByLogin(string login, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login, cancellationToken: ct);
    }

    public async Task Add(User user, CancellationToken ct)
    {
        await _context.Users.AddAsync(user, ct);
        await _context.SaveChangesAsync(ct);
    }
}