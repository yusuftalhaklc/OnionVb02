using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string categorName, string description)
        {
            CategorName = categorName;
            Description = description;
        }

        public string CategorName { get; set; }
        public string Description { get; set; }
    }
}
