using System;

namespace ReverseGeo
{
    public static class GlobalConst
    {
        /// <summary>
        /// Opening part of request to Google API
        /// </summary>
        public const string APIRequestStarter = "https://maps.googleapis.com/maps/api/geocode/json";

        /// <summary>
        /// Opening part coords (latlng)
        /// </summary>
        public const string APICoordsStarter = "?latlng=";

        /// <summary>
        /// Opening part key 
        /// </summary>
        public const string APIKeyStarter = "&key=";

        /// <summary>
        /// Opening part location filter
        /// </summary>
        public const string APILocationStarter = "&location_type=";

        /// <summary>
        /// Opening part result filter
        /// </summary>
        public const string APIResultStarter = "&result_type=";

        /// <summary>
        /// Opening part Language
        /// </summary>
        public const string APILangStarter = "&language=";

        /// <summary>
        /// Switcher for Results filter
        /// </summary>
        public enum FilterResultTitles
        {
            None       = 0 // indicates without the filter
            , Address  = 1 // indicates a precise street address
            , Street   = 2 // indicates a named route (such as "US 101")
        }

        /// <summary>
        /// Switcher for Locations filter
        /// </summary>
        public enum FilterLocationTitles
        {
            None      = 0 // indicates without the filter
            , Address = 1 // returns only the addresses for which Google has location information accurate down to street address precision
        }

        /// <summary>
        /// Switcher for Request version
        /// </summary>
        public enum FilterRequestTitles
        {
            Short  = 1 // without parameters
            , Long = 2 // with parameters
        }

    }
}
