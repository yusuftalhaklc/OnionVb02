using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}

