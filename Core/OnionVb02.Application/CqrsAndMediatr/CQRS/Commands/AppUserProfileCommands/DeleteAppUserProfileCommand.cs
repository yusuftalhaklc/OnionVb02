using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class DeleteAppUserProfileCommand
    {
        public DeleteAppUserProfileCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

