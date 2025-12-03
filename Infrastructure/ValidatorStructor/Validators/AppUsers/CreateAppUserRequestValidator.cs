using FluentValidation;
using OnionVb02.Application.RequestModels.AppUsers;

namespace ValidatorStructor.Validators.AppUsers
{
    public class CreateAppUserRequestValidator : AbstractValidator<CreateAppUserRequestModel>
    {
        public CreateAppUserRequestValidator()
        {
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

