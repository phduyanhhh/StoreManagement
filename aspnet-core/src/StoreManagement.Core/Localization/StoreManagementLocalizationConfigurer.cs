using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace StoreManagement.Localization
{
    public static class StoreManagementLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(StoreManagementConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(StoreManagementLocalizationConfigurer).GetAssembly(),
                        "StoreManagement.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
