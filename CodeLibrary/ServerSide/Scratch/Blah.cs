using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.Scratch
{
  public static class Blah
  {
    public static void CheckForWhiteSpaceCharacters()
		{
			Console.WriteLine("Enter some white space");
			var sourceString = Console.ReadLine();

			var newLine         = "\r";
			var carraiageReturn = "\n";
			var horizontaTab    = "\t";
			var verticalTab     = "\v";
			var spaceBar        = " ";

			var result = (sourceString == newLine || sourceString == carraiageReturn || sourceString == horizontaTab || sourceString == verticalTab || sourceString == spaceBar);
			Console.WriteLine($"White space entered: {result}");
			Console.ReadLine();
		}

    private enum MismatchCheckResult
    {
      FoundNone,
      FoundFirst,
      FoundSecond
    }

    public static void CheckForCloseMatch()
    {
      var indexName           = "FTSE All-Share Index".ToLower();
      var loopIndexName       = "FTSE All Share Index".ToLower();      
      var indexFound          = false;
      var string1             = "all share";
      var string2             = "all-share";
      var mismatchCheckResult = MismatchCheckResult.FoundNone;

      if (indexName.Contains(string1) || indexName.Contains(string2))
      {        
        mismatchCheckResult = indexName.Contains(string1) ? MismatchCheckResult.FoundFirst : MismatchCheckResult.FoundSecond;
        indexName           = mismatchCheckResult == MismatchCheckResult.FoundFirst ? indexName.Replace(string1, string2) : indexName;        
      }

      loopIndexName = mismatchCheckResult != MismatchCheckResult.FoundNone ? loopIndexName.Replace(string1, string2) : loopIndexName;
      indexFound    = indexName == loopIndexName;
    }
      


		public static void GetRangeFromList()
		{
			var listMain = new List<string>();
			
			for (var i = 0; i < 10; i++)
			{
				listMain.Add($"Number: {i}");
			}

			var listSub = listMain.GetRange(3, 6);
		}
			


    public static string BlahBlah()
    {
      var a = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("Qkr43LvVLBs5MEu1Ecmm"));

      return a;
    }


    public static string TrimStringFromString(string sourceString, string stringToTrim)
    {
      //sourceString     = "FTSE All-World Index ";
      //stringToTrim     = "Index ";
      
      var returnString = sourceString.ToLower().Trim();
      sourceString     = sourceString.Trim();
      stringToTrim     = stringToTrim.ToLower().Trim();
      returnString     = sourceString.Substring(0, sourceString.Length-stringToTrim.Length).Trim();

      return returnString;
      //var numberOfCharsToTrim = (returnString.Substring(returnString.Length - stringToTrim.Length, stringToTrim.Length)).Length;
    }
  }
}
