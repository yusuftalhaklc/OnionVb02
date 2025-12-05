using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands
{
    public class UpdateProductCommand
    {
        public UpdateProductCommand(int id, string productName, decimal unitPrice, int? categoryId)
        {
            Id = id;
            ProductName = productName;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}

