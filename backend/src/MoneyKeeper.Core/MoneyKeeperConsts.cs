using MoneyKeeper.Debugging;

namespace MoneyKeeper
{
    public class MoneyKeeperConsts
    {
        public const string LocalizationSourceName = "MoneyKeeper";

        public const string ConnectionStringName = "Default";

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "5e90e438e01a483fb007afa6016483ba";
    }
}
