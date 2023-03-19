using MediatR;

namespace Application.MediatR.AuthoriseUser;

public class AuthorizeUserCommand : IRequest<AuthorizeUserCommandResult>
{
    public string Login { get; set; }

    public string Password { get; set; }

    public AuthorizeUserCommand(string login, string password)
    {
        Login = login;
        Password = password;
    }
}

public class AuthorizeUserCommandResult
{
    public int Id { get; set; }

    public AuthorizeUserCommandResult(int id)
    {
        Id = id;
    }
}