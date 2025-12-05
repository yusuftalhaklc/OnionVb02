using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}

