using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands
{
    public class CreateProductCommand
    {
        public CreateProductCommand(string productName, decimal unitPrice, int? categoryId)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }

        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}

