using FluentValidation;
using OnionVb02.Application.RequestModels.AppUsers;

namespace ValidatorStructor.Validators.AppUsers
{
    public class UpdateAppUserRequestValidator : AbstractValidator<UpdateAppUserRequestModel>
    {
        public UpdateAppUserRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
                .NotNull().WithMessage("Kullanıcı adı zorunludur")
                .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır")
                .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olabilir");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz")
                .NotNull().WithMessage("Şifre zorunludur")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır")
                .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir");
        }
    }
}

