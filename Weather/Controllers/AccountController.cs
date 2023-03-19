using Application.MediatR.AuthoriseUser;
using Application.MediatR.CreateUser;
using Lcb.Web.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Weather.Controllers;

[Controller]
[Route("[controller]/[action]")]
[ResponseCache(NoStore = true)]
public class AccountController : Controller
{
    private readonly IMediator _mediator;
    private readonly AuthorizerService _authorizerService;

    public AccountController(IMediator mediator, AuthorizerService authorizerService)
    {
        _authorizerService = authorizerService;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        var token = await _authorizerService.GenerateToken(result.Id.ToString());

        return Ok(token);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Login([FromBody] AuthorizeUserCommand command)
    {
        var result = await _mediator.Send(command);

        var token = await _authorizerService.GenerateToken(result.Id.ToString());

        return Ok(token);
    }
}