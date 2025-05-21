using StoreManagement.Debugging;

namespace StoreManagement
{
    public class StoreManagementConsts
    {
        public const string LocalizationSourceName = "StoreManagement";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f17df621ebe5409b8713bfee73d90678";
    }
}
