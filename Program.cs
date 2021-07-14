using System;

namespace ReverseGeo
{
    class Program
    {
        static void Main()
        {
            Logger.LogDebug("App started. Press Enter to start Reverse Geocoding");

            #region Preparation
                GeoPerformer performer = new(Settings.ApiKey);
            #endregion

            #region Communicate with Google

                double lat = 49.97573488097145;
                double lng = 16.970794198517307;

                Logger.LogDebug($"The App will geocode for coordinates: {lat}, {lng}");
                var result = performer.ReverseGeocode(lat, lng);
            #endregion

            #region Show results
                Logger.LogDebug($"Your address is {result}");
            #endregion 

            Logger.LogDebug("App ended. Press Enter to exit");
        }
    }
}
