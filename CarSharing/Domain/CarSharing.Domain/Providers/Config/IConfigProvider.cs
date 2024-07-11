namespace CarSharing.Domain.Providers.Config
{
    public interface IConfigProvider
    {
        string GetSetting(string settingName);
    }
}
