using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}

