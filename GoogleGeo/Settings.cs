using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseGeo
{
    public static class Settings
    {
        public static readonly string apiKey = "";

        public static readonly string ResultsFilterAddress = "address"; //indicates a precise street address
        public static readonly string ResultsFilterStreet = "street"; // indicates a named route

        public static readonly string LocationsFilterAddress = "address"; //returns only the addresses for which Google has location information accurate down to street address precision

        public static readonly string language = "en"; // the language in which to return results


        // https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&key=YOUR_API_KEY
        // https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&location_type=ROOFTOP&result_type=street_address&key=YOUR_API_KEY

    }
}
