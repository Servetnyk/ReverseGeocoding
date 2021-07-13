using System;

namespace ReverseGeo
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogDebug("Program started. Press Enter to start coding");

            #region Preparation
            GeoPerformer performer = new GeoPerformer(Settings.ApiKey);


            #endregion

            #region Communicate with Google
            #endregion

            #region Show results
            #endregion 

            Logger.LogDebug("Program ended. Press Enter to exit");
        }
    }
}
