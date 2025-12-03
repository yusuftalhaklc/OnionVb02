using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ValidatorStructor.Validators.AppUserProfiles;

namespace ValidatorStructor.DependencyResolvers
{
    public static class ValidatorResolver
    {
        public static void AddValidatorService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateAppUserProfileRequestValidator>();
        }
    }
}

