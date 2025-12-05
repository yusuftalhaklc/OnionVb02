using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}

