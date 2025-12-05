using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
        public DeleteOrderDetailCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

