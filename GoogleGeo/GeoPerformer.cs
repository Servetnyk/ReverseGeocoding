using System;
using System.Globalization;
using System.Net;
using Newtonsoft.Json;

namespace ReverseGeo
{
    public class GeoPerformer
    {
        private readonly string _apiKey;

        private readonly GlobalConst.FilterLocationTitles _defaultLocationFilter = GlobalConst.FilterLocationTitles.Address;
        private readonly string _defaultLanguage = "en";

        #region Public methods

        public GeoPerformer(string apiKey)
        {
            _apiKey = apiKey;
        }

        public string ReverseGeocode(double lat, double lng)
        {
            var url = CollectShortReverseRequest(lat, lng);

            string address;

            try
            {
                string response;
                using (var wc = new WebClient())
                {
                    response = wc.DownloadString(new Uri(url));
                }

                var result = JsonConvert.DeserializeObject<GeoCodeResponse>(response);
                address = result.Results[1].FormattedAddress;
            }
            catch (Exception ex)
            {
                address = "<not defined>";
                Logger.LogDebug($"Error: {ex}");
            }
            return address;
        }






        #endregion


        #region Private methods

            private string CollectReverseRequest(double lat, double lng, GlobalConst.FilterResultTitles resultsFilter)
            {
                return CollectLongReverseRequest(lat, lng, _defaultLocationFilter, resultsFilter, _defaultLanguage);
            }

            private string CollectShortReverseRequest(double lat, double lng)
            {
                return CollectLongReverseRequest(lat, lng, GlobalConst.FilterLocationTitles.None, GlobalConst.FilterResultTitles.None, "");
            }

            private string CollectLongReverseRequest(double lat, double lng,
                GlobalConst.FilterLocationTitles locationsFilter, GlobalConst.FilterResultTitles resultsFilter, string lang)
            {
                // sample: https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&location_type=ROOFTOP&result_type=street_address&key=YOURAPIKEY

                var coordsPart = $"{GlobalConst.APICoordsStarter}{lat.ToString(CultureInfo.InvariantCulture)},{lng.ToString(CultureInfo.InvariantCulture)}";
                var keyPart = $"{GlobalConst.APIKeyStarter}{Settings.ApiKey}";

                return GlobalConst.APIRequestStarter
                        + coordsPart
                        + getFilterLocations(locationsFilter)
                        + getFilterResults(resultsFilter)
                        + getFilterLang(lang)
                        + keyPart;
            }

            private string getFilterLocations(GlobalConst.FilterLocationTitles option)
            {
                return option switch
                {
                    GlobalConst.FilterLocationTitles.Address => $"{GlobalConst.APILocationStarter}ROOFTOP", 
                    _ => "",
                };
            }

            private string getFilterResults(GlobalConst.FilterResultTitles option)
            {
                return option switch
                {
                    GlobalConst.FilterResultTitles.Address => $"{GlobalConst.APIResultStarter}street_address",
                    GlobalConst.FilterResultTitles.Street => $"{GlobalConst.APIResultStarter}route", 
                    _ => "",
                };
            }

            private string getFilterLang(string option)
            {
                switch (option)
                {
                    case "en":
                    case "En":
                    case "EN": return $"{GlobalConst.APILangStarter}en";
                    default: return "";
                }
            }

        #endregion
    }
}
