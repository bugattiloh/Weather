using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherInfrastructure;
using WeatherInfrastructure.Repository;

namespace Application.MediatR.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }


    public async Task<CreateUserCommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userCheck = await _repository.GetUserByLogin(command.Login, cancellationToken);

        if (userCheck !=null)
        {
            throw new Exception("Такой логин уже есть");
        }
        var user = new User()
        {
            Login = command.Login,
            Password = command.Password
        };

        await _repository.Add(user,cancellationToken);

        return new CreateUserCommandResult(user.Id);
    }
}