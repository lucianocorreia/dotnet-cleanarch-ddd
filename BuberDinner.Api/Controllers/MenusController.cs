using System.Reflection.Metadata.Ecma335;
using BuberDinner.Api.Controllers;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api;

[Route("hosts/{hostId}/menus")]
// [Authorize]
public class MenusController : ApiController
{
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        [FromBody] CreateMenuRequest request,
        [FromRoute] HostId hostId
    )
    {
        var command = mapper.Map<CreateMenuCommand>(request);

        var createResult = await mediator.Send((command));
        return Ok(request);
    }

}
