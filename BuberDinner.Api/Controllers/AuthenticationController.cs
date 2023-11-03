using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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
        var result = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

        return Ok(response);
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = authenticationService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

        return Ok(response);
    }
}
