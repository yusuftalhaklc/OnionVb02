using FluentValidation;
using OnionVb02.Application.RequestModels.AppUserProfiles;

namespace ValidatorStructor.Validators.AppUserProfiles
{
    public class CreateAppUserProfileRequestValidator : AbstractValidator<CreateAppUserProfileRequestModel>
    {
        public CreateAppUserProfileRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz")
                .NotNull().WithMessage("Ad zorunludur")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz")
                .NotNull().WithMessage("Soyad zorunludur")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir");
        }
    }
}

