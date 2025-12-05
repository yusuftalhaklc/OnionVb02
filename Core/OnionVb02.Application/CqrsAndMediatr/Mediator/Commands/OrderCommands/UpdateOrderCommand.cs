using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}

