using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MoneyKeeper.Localization
{
    public static class MoneyKeeperLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MoneyKeeperConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MoneyKeeperLocalizationConfigurer).GetAssembly(),
                        "MoneyKeeper.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
