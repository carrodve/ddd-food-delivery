using AutoMapper;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
