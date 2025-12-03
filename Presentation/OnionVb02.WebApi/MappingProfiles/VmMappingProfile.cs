using AutoMapper;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.RequestModels.Categories;
using OnionVb02.Application.RequestModels.Products;
using OnionVb02.Application.RequestModels.AppUsers;
using OnionVb02.Application.RequestModels.AppUserProfiles;
using OnionVb02.Application.RequestModels.Orders;
using OnionVb02.Application.RequestModels.OrderDetails;
using OnionVb02.WebApi.ResponseModels.Categories;
using OnionVb02.WebApi.ResponseModels.Products;
using OnionVb02.WebApi.ResponseModels.AppUsers;
using OnionVb02.WebApi.ResponseModels.AppUserProfiles;
using OnionVb02.WebApi.ResponseModels.Orders;
using OnionVb02.WebApi.ResponseModels.OrderDetails;

namespace OnionVb02.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel,CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();

            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();

            CreateMap<CreateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<UpdateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetailResponseModel>();
        }
    }
}
