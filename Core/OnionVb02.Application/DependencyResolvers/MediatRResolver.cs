using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.CategoryHandlers.Read;

namespace OnionVb02.Application.DependencyResolvers
{
    public static class MediatRResolver
    {
        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQueryHandler).Assembly)
                );
        }
    }
}
