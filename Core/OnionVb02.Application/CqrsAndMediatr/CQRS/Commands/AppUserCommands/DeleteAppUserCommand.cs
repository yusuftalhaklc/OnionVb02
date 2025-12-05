using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class DeleteAppUserCommand
    {
        public DeleteAppUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

