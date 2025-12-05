using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}

