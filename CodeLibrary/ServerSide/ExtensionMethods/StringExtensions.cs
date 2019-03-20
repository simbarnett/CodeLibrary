using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.ExtensionMethods
{
  public static class StringExtensions
  {

    public static string CheckForSynonym<T>(this T sourceString1, string sourceString2, string textToReplace)
    {
      //var a = sourceString1.ToString().IndexOf(textToReplace)

      return string.Empty;
    }

    public static string TrimStringFromEnd(this string sourceString, string stringToTrim, bool ignoreCase = true)
    {
      var returnString        = sourceString;
      var sourceStringRestore = sourceString;

      if (ignoreCase)
      {        
        sourceString = sourceString.TrimEnd();
        stringToTrim = stringToTrim.ToLower().Trim();        

        if (sourceString.Length >= stringToTrim.Length)
        {
          var sourceStringEnd = string.Empty;
          sourceStringEnd     = sourceString.Substring(sourceString.Length - stringToTrim.Length).ToLower();

          if (sourceStringEnd == stringToTrim)
          {                   
            returnString = sourceString.Substring(0, sourceString.Length - stringToTrim.Length).Trim();
          }         
        }        
      }
      else
      {
        returnString = sourceString.Trim().Replace(stringToTrim.Trim(), string.Empty).Trim();
      }
      return returnString;     
    }
  }
}
