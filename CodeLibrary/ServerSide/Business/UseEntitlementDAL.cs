using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLibraryHelpers.Helpers;

namespace CodeLibrary.ServerSide.Business
{
  public static class UseEntitlementDAL
  {
    public static bool IsUserAuthorisedToViewCalendar()
    {
      var entitlementDALHelper    = new EntitlementDALHelper();
      //var userRepositiory = entitlementDALHelper.GetUserRepository();
      var entitlementKeys = entitlementDALHelper.GetEntitlementKeys();



      return true;
    }
  }
}
