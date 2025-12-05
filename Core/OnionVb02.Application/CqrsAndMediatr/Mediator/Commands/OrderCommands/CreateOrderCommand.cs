using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}

