using System;

namespace FoodDeliveryDemo.Configuration
{
    public struct GeoCoordinate : ICloneable
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public object Clone()
        {
            return new GeoCoordinate(Latitude, Longitude);
        }
    }
}
