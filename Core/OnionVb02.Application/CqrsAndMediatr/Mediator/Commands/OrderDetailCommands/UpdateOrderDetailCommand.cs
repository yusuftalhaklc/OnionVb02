using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand : IRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

