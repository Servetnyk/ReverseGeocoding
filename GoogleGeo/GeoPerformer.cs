using System;
using System.Globalization;
using System.Net;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace ReverseGeo
{
    public class GeoPerformer
    {
        private readonly string _Setting_ApiKey;
        private readonly GlobalConst.FilterResultTitles _Setting_ResultsFilter;
        private readonly GlobalConst.FilterLocationTitles _Setting_LocationsFilter;
        private readonly string _Setting_LanguageFilter;
        private readonly GlobalConst.FilterRequestTitles _Setting_RequestVersion;

        #region Public methods

        public GeoPerformer()
        {
            _Setting_ApiKey = Settings.ApiKey;

            if (!Enum.TryParse<GlobalConst.FilterResultTitles>
                (Settings.ResultsFilter, true, out _Setting_ResultsFilter))
                _Setting_ResultsFilter = GlobalConst.FilterResultTitles.None;

            if (!Enum.TryParse<GlobalConst.FilterLocationTitles>
                (Settings.LocationsFilter, true, out _Setting_LocationsFilter))
                _Setting_LocationsFilter = GlobalConst.FilterLocationTitles.None;

            _Setting_LanguageFilter  = Settings.LanguageFilter;

            if (!Enum.TryParse<GlobalConst.FilterRequestTitles>
                (Settings.RequestVersion, true, out _Setting_RequestVersion))
                _Setting_RequestVersion = GlobalConst.FilterRequestTitles.Short;
        }

        public string ReverseGeocode(double lat, double lng)
        {
            string uri = "";
            switch (_Setting_RequestVersion)
            {
                case GlobalConst.FilterRequestTitles.Short :
                    // Logger.LogDebug("Calling Short method");
                    uri = CollectShortReverseRequest(lat, lng);
                    break;
                case GlobalConst.FilterRequestTitles.Long :
                    // Logger.LogDebug($"Calling Long method with settings {_Setting_LocationsFilter}, {_Setting_ResultsFilter}, {_Setting_LanguageFilter}");
                    uri = CollectLongReverseRequest(lat, lng);
                    break;
                default:
                    // Logger.LogDebug($"Calling default method with settings {GlobalConst.FilterLocationTitles.None}, {GlobalConst.FilterResultTitles.None} ");
                    uri = CollectReverseRequest(lat, lng, GlobalConst.FilterLocationTitles.None, GlobalConst.FilterResultTitles.None, "");
                    break;
            }
            Logger.LogDebug($"Uri is {uri}");

            string address = "";
            try
            {
                string webResponse;
                using (var wc = new WebClient())
                {
                    webResponse = wc.DownloadString(new Uri(uri));
                }

                var deserializeResult = JsonConvert.DeserializeObject<Root>(webResponse);
                address = deserializeResult.Status switch
                {
                    "OK"              => deserializeResult.Results[0].FormattedAddress,
                    "ZERO_RESULTS"    => "<the request was successful but returned no results>",
                    "REQUEST_DENIED"  => "<the request was denied>",
                    "INVALID_REQUEST" => "<invalid request or fails in query>",
                    _                 => "<the request could not be processed>"
                };
            }
            catch (Exception ex)
            {
                address = "<exception, address not defined>";
                Logger.LogDebug($"Error: {ex}");
            }
            return address;
        }
        #endregion


        #region Private methods

            private string CollectShortReverseRequest(double lat, double lng)
            {
                return CollectReverseRequest(lat, lng, GlobalConst.FilterLocationTitles.None, GlobalConst.FilterResultTitles.None, _Setting_LanguageFilter);
            }

            private string CollectLongReverseRequest(double lat, double lng)
            {
                return CollectReverseRequest(lat, lng, _Setting_LocationsFilter, _Setting_ResultsFilter, _Setting_LanguageFilter);
            }

            private string CollectReverseRequest(
                    double lat, double lng
                    , GlobalConst.FilterLocationTitles locationFilter
                    , GlobalConst.FilterResultTitles resultFilter
                    , string langFilter)
            {
                // sample: https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&location_type=ROOFTOP&result_type=street_address&language=en&key=YOURAPIKEY
                
                var coordsPart = $"{GlobalConst.APICoordsStarter}{lat.ToString(CultureInfo.InvariantCulture)},{lng.ToString(CultureInfo.InvariantCulture)}";
                var keyPart = $"{GlobalConst.APIKeyStarter}{_Setting_ApiKey}";

                return GlobalConst.APIRequestStarter
                       + coordsPart
                       + getFilterLocations(locationFilter)
                       + getFilterResults(resultFilter)
                       + getFilterLang(langFilter)
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
                if (option.Length > 1 && option.Length < 6)
                    return $"{GlobalConst.APILangStarter}{option.ToLower()}";
                else
                    return "";
            }

        #endregion
    }
}
