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
        public const string APILangStarter = "&Language=";

        /// <summary>
        /// Switcher for Results filter
        /// </summary>
        public enum FilterResultTitles
        {
            Address //indicates a precise street address
            , Street // indicates a named route (such as "US 101")
            , None // indicates without the filter
        }

        /// <summary>
        /// Switcher for Locations filter
        /// </summary>
        public enum FilterLocationTitles
        {
            Address //indicates a precise street address
            , None // indicates without the filter
        }



    }
}
