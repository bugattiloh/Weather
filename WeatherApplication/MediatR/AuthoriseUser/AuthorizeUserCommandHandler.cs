using MediatR;
using WeatherInfrastructure.Repository;

namespace Application.MediatR.AuthoriseUser;

public class AuthorizeUserCommandHandler : IRequestHandler<AuthorizeUserCommand,AuthorizeUserCommandResult>
{
    private readonly IUserRepository _repository;

    public AuthorizeUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuthorizeUserCommandResult> Handle(AuthorizeUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByLogin(command.Login, cancellationToken);

        if (user is null)
        {
            throw new Exception("Пользователь не найден");
        }

        if (user.Password != command.Password)
        {
            throw new Exception("Invalid password");
        }

        return new AuthorizeUserCommandResult(user.Id);
    }
}