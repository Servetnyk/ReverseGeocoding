using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ReverseGeo.GoogleGeo
{
    public class GeoPerformer
    {
        private readonly string _apiRequestStarting = "https://maps.googleapis.com/maps/api/geocode/json";
        private readonly string _defaultLocationFilter = "address";
        private readonly string _defaultLanguage = "en";



        #region Public methods

        public void GetAddressByCoord

        private HttpClient client = new HttpClient();


        #endregion


        #region Private methods

        private string CollectReverseRequest(float lat, float lng, string resultsFilter)
            {
                return CollectLongReverseRequest(lat, lng, _defaultLocationFilter, resultsFilter, _defaultLanguage);
            }

            private string CollectShortReverseRequest(float lat, float lng)
            {
                return CollectLongReverseRequest(lat, lng, "", "", "");
            }

            private string CollectLongReverseRequest(float lat, float lng, string locationsFilter, string resultsFilter, string lang)
            {
                // sample: https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&location_type=ROOFTOP&result_type=street_address&key=YOUR_API_KEY
                return _apiRequestStarting + $"?latlng={lat},{lng}"
                        + getFilterLocations(locationsFilter) + getFilterResults(resultsFilter)
                        + getFilterLang(lang) + $"&key={Settings.apiKey}";
            }

            private string getFilterLocations(string option)
            {
                return option switch
                {
                    "address" => "&location_type=ROOFTOP", //indicates a precise street address
                    _ => "",
                };
            }

            private string getFilterResults(string option)
            {
                return option switch
                {
                    "address" => "&result_type=street_address", //indicates a precise street address
                    "street" => "&result_type=route", // indicates a named route (such as "US 101")
                    _ => "",
                };
            }

            private string getFilterLang(string option)
            {
                switch (option)
                {
                    case "en":
                    case "En":
                    case "EN": return "&language=en";
                    default: return "";
                }
            }

        #endregion
    }
}
