using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand : IRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

