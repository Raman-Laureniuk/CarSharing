namespace CarSharing.Infrastructure.Providers.Config
{
    using System;
    using System.Threading;
    using CarSharing.Domain.Providers.Config;
    using Microsoft.Extensions.Configuration;

    public class ConfigProvider : IConfigProvider
    {
        private static readonly Lazy<IConfigurationRoot> _configuration = new Lazy<IConfigurationRoot>(
            () => new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build(),
            LazyThreadSafetyMode.ExecutionAndPublication
        );
        
        public string GetSetting(string settingName)
        {
            return _configuration.Value[settingName];
        }
    }
}
