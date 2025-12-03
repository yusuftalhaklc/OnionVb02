using FluentValidation;
using OnionVb02.Application.RequestModels.Categories;

namespace ValidatorStructor.Validators.Categories
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz")
                .NotNull().WithMessage("Kategori adı zorunludur")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir");
        }
    }
}

