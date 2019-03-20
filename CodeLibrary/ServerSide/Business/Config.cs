using CodeLibraryHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeLibrary.ServerSide.Business
{
  class Config
  {
    public void UseConfigHelper()
    {
      //ConfigHelper.GetConfigValue("Environment");
      //ConfigHelper.GetConnectionString("ConnectionString");
      ConfigHelper.CheckIfUrlContainsDomainFromConfig("https://ra-stes-web01/analytics/ftseportal/Registration/CheckUser", "secureDomains");
    }
  }
}
