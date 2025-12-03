using FluentValidation;
using OnionVb02.Application.RequestModels.OrderDetails;

namespace ValidatorStructor.Validators.OrderDetails
{
    public class CreateOrderDetailRequestValidator : AbstractValidator<CreateOrderDetailRequestModel>
    {
        public CreateOrderDetailRequestValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Sipariş ID 0'dan büyük olmalıdır");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün ID 0'dan büyük olmalıdır");
        }
    }
}

