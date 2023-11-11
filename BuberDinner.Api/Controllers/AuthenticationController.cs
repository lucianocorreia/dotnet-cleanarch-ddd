using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        return authResult.Match(
            authResult => Ok(mapper.Map<AuthenticationResult>(authResult)),
            errors => Problem(errors));
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var authResult = await mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                detail: authResult.FirstError.Description
            );
        }

        return authResult.Match(
             authResult => Ok(mapper.Map<AuthenticationResult>(authResult)),
             errors => Problem(errors));
    }
}
