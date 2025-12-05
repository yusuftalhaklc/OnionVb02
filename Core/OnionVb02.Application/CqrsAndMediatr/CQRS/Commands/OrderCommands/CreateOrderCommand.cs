using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands
{
    public class CreateOrderCommand
    {
        public CreateOrderCommand(string shippingAddress, int? appUserId)
        {
            ShippingAddress = shippingAddress;
            AppUserId = appUserId;
        }

        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}

