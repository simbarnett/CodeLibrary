using System.Configuration;

namespace CodeLibraryHelpers.Helpers
{
  public static class ConfigHelper
  {
    public static string GetConfigValue(string configKey)
    {
      var configValue = string.Empty;
      if (!string.IsNullOrEmpty(configKey))
      {
        configValue = ConfigurationManager.AppSettings[configKey];
      }

      return configValue;
    }

    public static string GetConnectionString(string connectionKey)
    {
      var configValue = string.Empty;
      if (!string.IsNullOrEmpty(connectionKey))
      {        
        configValue = ConfigurationManager.ConnectionStrings[connectionKey].ToString();
      }

      return configValue;
    }

    public static bool CheckIfUrlContainsDomainFromConfig(string url, string configKey)
    {
      var domain = url.Split('/')[2];
      var configValues = ConfigHelper.GetConfigValue("secureDomains").Split(',');
      bool isSecure = false;

      foreach (var value in configValues)
      {
        if (!isSecure)
        {
          isSecure = value.ToLower() == domain.ToLower();
        }
      }
      return isSecure;
    }

  }
}
