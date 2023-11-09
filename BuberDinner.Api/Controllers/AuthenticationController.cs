using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    public readonly IAuthenticationService authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapToResponse(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapToResponse(AuthenticationResult result)
    {
        return new AuthenticationResponse(
                    result.User.Id,
                    result.User.FirstName,
                    result.User.LastName,
                    result.User.Email,
                    result.Token);
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var authResult = authenticationService.Login(
            request.Email,
            request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                detail: authResult.FirstError.Description
            );
        }

        return authResult.Match(
             authResult => Ok(MapToResponse(authResult)),
             errors => Problem(errors));
    }
}
