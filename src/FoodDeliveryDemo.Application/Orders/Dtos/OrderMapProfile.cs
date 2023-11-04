using AutoMapper;
using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.DeliveryLocation.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.DeliveryLocation.Longitude));
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.DeliveryLocation, opt => opt.MapFrom(src =>
                    new GeoCoordinate(src.Latitude, src.Longitude)));
        }
    }
}
