using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand
    {
        public UpdateOrderDetailCommand(int id, int orderId, int productId)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

