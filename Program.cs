using System;

namespace ReverseGeo
{
    class Program
    {
        static void Main()
        {
            Logger.LogDebug("App started. Press Enter to start Reverse Geocoding");

            #region Preparation
                GeoPerformer performer = new();
            #endregion

            #region Communicate with Google

                Logger.LogDebug($"The App will geocode for coordinates: {Settings.LetLat}, {Settings.LetLng}");
                var result = performer.ReverseGeocode(Settings.LetLat, Settings.LetLng);
            #endregion

            #region Show results
                Logger.LogDebug($"Your address is {result}");
            #endregion 

            Logger.LogDebug("App ended. Press Enter to exit");
        }
    }
}
