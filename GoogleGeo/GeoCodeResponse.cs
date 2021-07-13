using System;

namespace ReverseGeo
{

    public class GeoCodeResponse
    {
        public string Status { get; set; }
        public Result[] Results { get; set; }
    }

    public record Result
    {
        public string FormattedAddress { get; set; }
        public Geometry Geometry { get; set; }
        public string[] Types { get; set; }
        public AddressComponent[] AddressComponents { get; set; }
    }

    public class Geometry
    {
        public string LocationType { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class AddressComponent
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string[] Types { get; set; }
    }

}
