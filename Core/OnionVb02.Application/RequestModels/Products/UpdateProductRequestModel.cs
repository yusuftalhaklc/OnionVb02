namespace OnionVb02.Application.RequestModels.Products
{
    public class UpdateProductRequestModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

