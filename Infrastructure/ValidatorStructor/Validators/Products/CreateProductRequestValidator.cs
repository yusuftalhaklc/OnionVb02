using FluentValidation;
using OnionVb02.Application.RequestModels.Products;

namespace ValidatorStructor.Validators.Products
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz")
                .NotNull().WithMessage("Ürün adı zorunludur")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Birim fiyat 0'dan büyük olmalıdır");
        }
    }
}

