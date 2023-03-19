using MediatR;

namespace Application.MediatR.CreateUser;

public class CreateUserCommand : IRequest<CreateUserCommandResult>
{
    public string Login { get; set; }

    public string Password { get; set; }

    public CreateUserCommand(string login, string password)
    {
        Login = login;
        Password = password;
    }
}

public class CreateUserCommandResult
{
    public int Id { get; set; }

    public CreateUserCommandResult(int id)
    {
        Id = id;
    }
}