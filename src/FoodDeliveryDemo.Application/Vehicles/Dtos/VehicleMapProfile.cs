using AutoMapper;
using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Vehicles.Dtos
{
    public class VehicleMapProfile : Profile
    {
        public VehicleMapProfile()
        {
            CreateMap<CreateVehicleDto, Vehicle>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.CurrentLocation.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.CurrentLocation.Longitude));
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.CurrentLocation, opt => opt.MapFrom(src => 
                    new GeoCoordinate(src.Latitude, src.Longitude)));
        }
    }
}
