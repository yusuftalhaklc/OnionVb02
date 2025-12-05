using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class UpdateAppUserCommand
    {
        public UpdateAppUserCommand(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

