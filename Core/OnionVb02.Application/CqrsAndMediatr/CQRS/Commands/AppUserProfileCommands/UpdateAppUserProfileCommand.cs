using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class UpdateAppUserProfileCommand
    {
        public UpdateAppUserProfileCommand(int id, string firstName, string lastName, int appUserId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AppUserId = appUserId;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

