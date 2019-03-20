using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeLibrary.ServerSide;
//using CodeLibrary.ServerSide.Helpers;
using CodeLibraryHelpers.ExtensionMethods;
using CodeLibrary.ServerSide.Business;
using CodeLibrary.ServerSide.Scratch;
using System.Xml;
using CodeLibraryHelpers.Helpers;

namespace CodeLibrary
{
  class Program
  {
    static void Main(string[] args)
    {
			//GetNumberOfFiles();
			//BackUpFiles();
			//Logging();
			//Config();      
			//StringManipulation();      
			//ConsumeXml();      
			//TestEmptyString(null);
			//LinqTest();
			//var a = Blah.BlahBlah();
			//StringManipulation();
			//TestExtensionMethod();
			//Blah.CheckForCloseMatch();
			//LazyScratch.UseLazy();
			//UseEntitlementDAL();
			//GetRichText();
			//GetIndexFamilyName();
			//GetHtml();
			//TypeConversionScratch.StringToDate();			
			//DateScratch.ConvertDate();
			//Blah.GetRangeFromList();
			Blah.CheckForWhiteSpaceCharacters();
		}


		private static void GetHtml()
		{
			var htmlString = UseHtmlTemplateHelper.GetHtml();
		}

    private static void GetIndexFamilyName()
    {
			var callSqlFunction = new CallSqlFunction();
			var indexFamilyCode = callSqlFunction.GetIndexFamilyCode("XINA50");
		}

    private static void GetRichText()
    {
      var plainText = RichText.GetPlainTextFromRichTextFile();
    }

    private static void UseEntitlementDAL()
    {
      //ServerSide.Business.UseEntitlementDAL.UseSayHelloMethod();
    }

    private static void TestExtensionMethod()
    {
      //var sourceString = "FTSE All-World Index ";
      var sourceString = "index";
      var stringToTrim = "index ";
      var trimmedString = sourceString.TrimStringFromEnd(stringToTrim, true);
      trimmedString = string.Empty;
    }

    private static void BackUpFiles()
    {
      var io = new IO();
      io.BackUpFiles();
    }

    private static void GetNumberOfFiles()
    {
      var io = new IO();
      var count = io.GetNumberOfFiles(ConfigHelper.GetConfigValue("BackUpSourcePath"));
    }

    private static void LinqTest()
    {
      LinqScratch.GetThisThing("blue");
    }

    private static void TestEmptyString(string theString)
    {
      var a = theString.ToLower();
    }

    private static void ConsumeXml()
    {
      var xmlConsumer = new ConsumeXml();
      //xmlConsumer.UseXmlHelper();
      xmlConsumer.TraverseTnConfigXml();
    }

    private static List<string> GetStringList()
    {
      return null;
    }

    
    public static void Logging()
    {
      var logging = new Logging();
      logging.UseLoggingHelper();
    }

    public static void Config()
    {
      var config = new Config();
      config.UseConfigHelper();
      
    }



    public static void  Cache()
    {
      var cache = new Cache();
      cache.UseCacheHelper();
    }

    public static void StringManipulation()
    {
      var stringManipulation = new StringManipulation();
      stringManipulation.UseStringManipulation();      
    }
  }
}
