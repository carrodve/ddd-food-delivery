using AutoMapper;

namespace FoodDeliveryDemo.Vehicles.Dtos
{
    public class VehicleMapProfile : Profile
    {
        public VehicleMapProfile()
        {
            CreateMap<CreateVehicleDto, Vehicle>();
        }
    }
}
