using AutoMapper;

namespace FoodDeliveryDemo
{
    /// <summary>
    /// Derivar los servicios de aplicación de esta clase.
    /// </summary>
    public abstract class FoodDeliveryDemoServiceBase
    {
        protected readonly IMapper ObjectMapper;

        protected FoodDeliveryDemoServiceBase(
            IMapper objectMapper)
        {
            ObjectMapper = objectMapper;
        }
    }
}
