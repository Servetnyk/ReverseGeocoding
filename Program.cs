using System;

namespace ReverseGeo
{
    class Program
    {
        static void Main()
        {
            Logger.LogDebug("Program started. Press Enter to start coding");

            #region Preparation
            GeoPerformer performer = new(Settings.ApiKey);
            
            var result = performer.ReverseGeocode(34.36556, 23.2343242);

            Logger.LogDebug(result);

            // https://github.com/evancummings/google.maps.geocoding/blob/master/google.maps.geocoder/GeoCoder.cs

            #endregion

            #region Communicate with Google
            #endregion

            #region Show results
            #endregion 

            Logger.LogDebug("Program ended. Press Enter to exit");
        }
    }
}
