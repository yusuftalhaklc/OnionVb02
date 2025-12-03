using FluentValidation;
using OnionVb02.Application.RequestModels.AppUserProfiles;

namespace ValidatorStructor.Validators.AppUserProfiles
{
    public class UpdateAppUserProfileRequestValidator : AbstractValidator<UpdateAppUserProfileRequestModel>
    {
        public UpdateAppUserProfileRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır");

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

