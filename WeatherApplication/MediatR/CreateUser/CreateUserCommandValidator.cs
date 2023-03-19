using FluentValidation;

namespace Application.MediatR.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty();
    }
}