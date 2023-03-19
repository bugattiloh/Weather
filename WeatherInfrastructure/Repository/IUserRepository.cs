namespace WeatherInfrastructure.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByLogin(string login, CancellationToken ct);

    Task Add(User user,CancellationToken ct);
}