using FluentValidation;
using OnionVb02.Application.RequestModels.OrderDetails;

namespace ValidatorStructor.Validators.OrderDetails
{
    public class UpdateOrderDetailRequestValidator : AbstractValidator<UpdateOrderDetailRequestModel>
    {
        public UpdateOrderDetailRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Sipariş ID 0'dan büyük olmalıdır");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün ID 0'dan büyük olmalıdır");
        }
    }
}

