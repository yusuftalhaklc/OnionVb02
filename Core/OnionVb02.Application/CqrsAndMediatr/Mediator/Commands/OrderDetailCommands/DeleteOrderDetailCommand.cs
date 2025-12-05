using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand : IRequest
    {
        public int Id { get; set; }
    }
}

