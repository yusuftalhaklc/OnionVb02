using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Read;

namespace OnionVb02.Application.DependencyResolvers
{
    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {
            // Category Handlers
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<DeleteCategoryCommandHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();

            // Product Handlers
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<DeleteProductCommandHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<GetProductQueryHandler>();

            // AppUser Handlers
            services.AddScoped<CreateAppUserCommandHandler>();
            services.AddScoped<UpdateAppUserCommandHandler>();
            services.AddScoped<DeleteAppUserCommandHandler>();
            services.AddScoped<GetAppUserByIdQueryHandler>();
            services.AddScoped<GetAppUserQueryHandler>();

            // AppUserProfile Handlers
            services.AddScoped<CreateAppUserProfileCommandHandler>();
            services.AddScoped<UpdateAppUserProfileCommandHandler>();
            services.AddScoped<DeleteAppUserProfileCommandHandler>();
            services.AddScoped<GetAppUserProfileByIdQueryHandler>();
            services.AddScoped<GetAppUserProfileQueryHandler>();

            // Order Handlers
            services.AddScoped<CreateOrderCommandHandler>();
            services.AddScoped<UpdateOrderCommandHandler>();
            services.AddScoped<DeleteOrderCommandHandler>();
            services.AddScoped<GetOrderByIdQueryHandler>();
            services.AddScoped<GetOrderQueryHandler>();

            // OrderDetail Handlers
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<DeleteOrderDetailCommandHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<GetOrderDetailQueryHandler>();
        }
    }
}
