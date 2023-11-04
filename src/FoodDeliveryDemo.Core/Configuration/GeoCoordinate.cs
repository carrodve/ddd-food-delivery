using System;

namespace FoodDeliveryDemo.Configuration
{
    public class GeoCoordinate
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object obj)
        {
            if (obj is GeoCoordinate other)
            {
                return Latitude == other.Latitude && Longitude == other.Longitude;
            }
            return false;
        }
    }
}
