namespace SpeakerManagementSystem.Infrastructure
{
    public static partial class ConfigExtensions
    {
        #region fields

        private static readonly string _nextJobScheduleRunTimeSection = "NextJobScheduleRunTime";

        #endregion fields

        /// <summary>
        /// SpeakerManagement: Returns the current environment.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string AspNetCoreEnvironment(this IConfiguration config)
        {
            return "";// config["ASPNETCORE_ENVIRONMENT"];
        }

        /// <summary>
        /// SpeakerManagement: Connection String Type One
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private static string SpeakerManagementContextConnection(this ConfigurationManager config)
        {
            // Set the value of the PGManagementContextConnection.
            var connString = config["SpeakerManagement:Database:ConnectionStrings:SpeakerManagementContextConnection"] ?? "";
            connString = connString.Replace("{ServerName}", config["SpeakerManagement:Database:Credentials:Server"]);
            return connString ?? "";
        }

        /// <summary>
        /// SpeakerManagement: Connection String for SpeakerManagement database.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string SpeakerManagementConnectionString(this ConfigurationManager config)
        {
            var databaseName = config["SpeakerManagement:Database:Credentials:Database"];
            var result = config.SpeakerManagementContextConnection().Replace("{DatabaseName}", databaseName);
            return result;
        }
    }
}
