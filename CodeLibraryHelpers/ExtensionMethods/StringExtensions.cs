using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeLibraryHelpers.ExtensionMethods
{
  public static class StringExtensions
  {

    public static string CheckForSynonym<T>(this T sourceString1, string sourceString2, string textToReplace)
    {
      //var a = sourceString1.ToString().IndexOf(textToReplace)

      return string.Empty;
    }
		
		public static string TrimCharsFromString(this string sourceString, int numberOfChars, Enums.StartOrEnd startOrEnd)
		{
			var returnString = string.Empty;
			if (startOrEnd == Enums.StartOrEnd.Start)
			{
				returnString = sourceString.Substring(numberOfChars);
			}
			else
			{
				returnString = sourceString.Substring(0, sourceString.Length - numberOfChars - 1);
			}
			
			return returnString;
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


		public static string RichTextToPlainText(this string richText)
		{
			string plainText;

			using (var richTextBox = new RichTextBox())
			{
				richTextBox.Rtf = richText;
				plainText = richTextBox.Text;
			}

				return plainText;
		}

		public static bool HasValue(this string sourceString)
		{
			return !string.IsNullOrEmpty(sourceString) && !string.IsNullOrWhiteSpace(sourceString) ? true : false;
		}

	}
}
