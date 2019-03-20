using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide
{
  public static class Scratch
  {
    public static string StripTrailingSlash(string location)
    {        
      var lastChar = GetLastChar(location);

      if (lastChar == "/" || lastChar == @"\")
      {
        location = location.Substring(0, location.Length - 1);
      }

      lastChar = GetLastChar(location);

      if (lastChar == "/" || lastChar == @"\")
      {
        location = StripTrailingSlash(location);
      }

      return location;
    }

    public static string GetLastChar(string location)
    {
      var locationLength = location.Length;      
      var newLocation = location.Substring(locationLength - 1);
      return newLocation;
    }
  }
}
