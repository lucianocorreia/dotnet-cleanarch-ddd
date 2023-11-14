using System.Reflection.Metadata.Ecma335;
using BuberDinner.Api.Controllers;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api;

[Route("hosts/{hostId}/menus")]
// [Authorize]
public class MenusController : ApiController
{
    [HttpPost]
    public IActionResult CreateMenu(
        [FromBody] CreateMenuRequest request,
        [FromRoute] HostId hostId
    )
    {
        return Ok(request);
    }

}
