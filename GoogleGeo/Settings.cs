using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseGeo
{
    public static class Settings
    {
        public static readonly string ApiKey = "AIzaSyApuE9xBAlUFwSq5XYPClVcd3sTVh6x5gA";

        public static readonly string ResultsFilter = "address"; //indicates a precise street address

        public static readonly string LocationsFilter = "address"; //returns only the addresses for which Google has location information accurate down to street address precision

        public static readonly string LanguageFilter = "en"; // the Language in which to return results

        public static readonly string RequestVersion = "long";
        // short : https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&key=YOURAPIKEY
        // long  : https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&location_type=ROOFTOP&result_type=street_address&key=YOURAPIKEY

    }
}
