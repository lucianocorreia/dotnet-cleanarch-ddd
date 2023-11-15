using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Menu.Create(
            request.HostId,
            request.Name,
            request.Description,
            request.Sections.Select(s => MenuSection.Create(
                s.Name,
                s.Description,
                s.Items.Select(i => MenuItem.Create(i.Name, i.Description)).ToList()
            )).ToList()
        );

        return default!;
    }
}
