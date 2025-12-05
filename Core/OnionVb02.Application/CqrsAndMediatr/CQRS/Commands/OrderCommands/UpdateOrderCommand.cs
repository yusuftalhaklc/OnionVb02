using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands
{
    public class UpdateOrderCommand
    {
        public UpdateOrderCommand(int id, string shippingAddress, int? appUserId)
        {
            Id = id;
            ShippingAddress = shippingAddress;
            AppUserId = appUserId;
        }
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}

