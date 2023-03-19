using FluentValidation;

namespace Application.MediatR.AuthoriseUser;

public class AuthorizeUserCommandValidator : AbstractValidator<AuthorizeUserCommand>
{
    public AuthorizeUserCommandValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty();
    }
}