using FluentValidation;
using OnionVb02.Application.RequestModels.Orders;

namespace ValidatorStructor.Validators.Orders
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Teslimat adresi boş olamaz")
                .NotNull().WithMessage("Teslimat adresi zorunludur")
                .MaximumLength(500).WithMessage("Teslimat adresi en fazla 500 karakter olabilir");
        }
    }
}

