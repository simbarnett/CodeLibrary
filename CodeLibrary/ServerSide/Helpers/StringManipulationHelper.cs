using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLibrary.ServerSide.Enums;
using System.Text.RegularExpressions;
using System.Xml;

namespace CodeLibrary.ServerSide.Helpers
{
  public static class StringManipulationHelper
  {    
    public static void ReplaceMarker()
    {
      XmlHelper xmlHelper = new XmlHelper();
      var xmlDocument = xmlHelper.GetXmlDocument(ConfigHelper.GetConfigValue("XmlDocumentPath"));
      xmlHelper = new XmlHelper(xmlDocument);
      var topElement = xmlDocument.SelectSingleNode("TestXmlDocument");
      var replaceMarkerNode = topElement.SelectSingleNode("ReplaceMarker") as XmlNode;
      var replaceMarkerTextNode = replaceMarkerNode.SelectSingleNode("Text");
      var replaceMarkerLinkNode = replaceMarkerNode.SelectSingleNode("Link");

      string pattern = string.Format("@@(.+?)@@");
      var match = Regex.Match(replaceMarkerTextNode.InnerText, pattern, RegexOptions.IgnoreCase);

      var newText = replaceMarkerTextNode.InnerText.Replace(match.ToString(), $@"<a href=""{replaceMarkerLinkNode.InnerText}"">{replaceMarkerTextNode.InnerText.Replace("@@", string.Empty)}</a>");


      //var match = Regex.Match(sourceText, pattern, RegexOptions.IgnoreCase);

      //var targetText = sourceText.Replace(match.ToString(), " yeah ");
    }

    public static string SetBackgroundUrlForRegistrationLayout(string currentUrlScheme, string url)
    {
      var urlSchemeInResourcepath = GetUrlScheme(url);

      if (currentUrlScheme != urlSchemeInResourcepath)
      {
        var urlWithUrlSchemeRemoved = StripUrlSchemeFromUrl(url);
        url = (currentUrlScheme.ToLower() == Enums.Enums.UrlScheme.http.ToString() || currentUrlScheme.ToLower() == Enums.Enums.UrlScheme.https.ToString()) ? $"{currentUrlScheme}{urlWithUrlSchemeRemoved}" : url;
      }

      return url;
    }


    public static string StripUrlSchemeFromUrl(string url)
    {
      var urlParts = url.Split('/');

      if (urlParts.Count() > 1)
      {
        var urlScheme = RemoveEndChars(urlParts[0], 1);
        var urlStripped = url.Replace(urlScheme, string.Empty);
        return urlStripped;
      }

      return url;
    }

    public static string RemovePortNumberFromUrl(string url)
    {
      var urlParts = url.Split('/');
      if (urlParts != null)
      {
        var domain = urlParts.Length > 2 ? urlParts[2] : string.Empty;
        var domainParts = domain.Split(':');

        if (domainParts != null)
        {
          var domainWithNoPort = domainParts.Length > 1 ? domainParts[0] : string.Empty;
          url = ((!string.IsNullOrEmpty(domainWithNoPort)) && (!string.IsNullOrEmpty(domainWithNoPort))) ? url.Replace(domain, domainWithNoPort) : url;
        }
      }

      return url;
    }

    public static string ReplaceIncorrectDomain(string url, string environment = null)
    {
      var urlParts = url.Split('/');
      if (urlParts.Length > 1)
      {
        environment = string.IsNullOrEmpty(environment) ? ConfigHelper.GetConfigValue("environment") : environment;
        environment = environment.Replace("http://", string.Empty);
        urlParts[2] = environment;

        var stringBuilder = new StringBuilder();

        foreach (var part in urlParts)
        {
          stringBuilder.Append($"{part}/");
        }

        var newUrl = stringBuilder.ToString();
        return newUrl.Substring(0, newUrl.Length - 1);
      }
      else
      {
        return url;
      }
    }

    public static string SwitchUrlProtocol(string url)
    {
      var urlParts = url.Split('/');
      urlParts[0] = urlParts[0] == "http:" ? "https:" : "http:";
      var stringBuilder = new StringBuilder();

      foreach (var part in urlParts)
      {
        if (!(string.IsNullOrEmpty(part) || string.IsNullOrWhiteSpace(part)))
        {
          stringBuilder.Append($"{part}/");
        }
      }

      url = stringBuilder.ToString();
      return url;
    }

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


    public static string GetUrlScheme(string url)
    {
      var urlScheme = string.Empty;
      urlScheme     = (!(string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))) ? RemoveEndChars(url.Split('/')[0], 1) : urlScheme;
      return urlScheme;
    }

    public static string RemoveEndChars(string theString, int quantity)
    {
      if (string.IsNullOrEmpty(theString) || string.IsNullOrWhiteSpace(theString))
      {
        return theString;        
      }

      return theString.Length >= quantity ? theString.Substring(0, theString.Length - quantity) : string.Empty;
    }
        
  }
}
