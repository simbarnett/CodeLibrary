using System;
using System.IO;
using System.Xml;

namespace CodeLibrary.ServerSide.Helpers
{
  public class XmlHelper
  {
    private XmlDocument TheXmlDocument { get; set; }

    public XmlHelper(XmlDocument xmlDocument = null)
    {
      TheXmlDocument = xmlDocument;
    }

    public XmlDocument GetXmlDocument(string xmlFilePath)
    {
      var useCaching  = ConfigHelper.GetConfigValue("UseCaching")?.ToString().ToLower() == "true" ? true : false;
      var cacheKey    = string.Empty;
      XmlDocument doc = null;
      
      if (useCaching)
      {
        cacheKey = "CachedData";
        doc = CacheHelper.GetFromCache(cacheKey) as XmlDocument;
      }
      
      if (doc == null)
      {
        doc                          = new XmlDocument();
        XmlTextReader templateReader = null;
        FileStream xmlStream         = null;

        try
        {
          xmlStream      = new FileStream(xmlFilePath, FileMode.Open);
          templateReader = new XmlTextReader(xmlStream);
          doc.Load(templateReader);

          if (useCaching)
          {
            CacheHelper.AddToCache(cacheKey, doc);
          }
        }
        catch (Exception ex)
        {
          LoggingHelper.AddLogEntry(ex.ToString());
        }

        finally
        {
          xmlStream?.Close();
          templateReader?.Close();
        }
      }

      return doc;
    }

    public XmlNode GetXmlFirstSingleNodeByName(string nodeName)
    {
      var xmlNode = TheXmlDocument.SelectSingleNode(nodeName);

      return xmlNode;
    }


    public int GetIntegerValueFromXml(string xmlElementName)
    {
      var returnValue = -1;

      if (TheXmlDocument != null)
      {
        var isInteger = false;
        var xmlNodeList = TheXmlDocument.GetElementsByTagName(xmlElementName);

        if (xmlNodeList != null && xmlNodeList.Count > 0)
        {
          isInteger = int.TryParse(xmlNodeList[0].InnerText, out returnValue);
        }

        returnValue = isInteger ? returnValue : -1;
      }
      return returnValue;
    }

    public int GetIntegerValueFromXml(string xmlElementName, int position)
    {
      var returnValue = -1;

      if (TheXmlDocument != null)
      {
        var isInteger = false;
        var xmlNodeList = TheXmlDocument.GetElementsByTagName(xmlElementName);

        if (xmlNodeList != null && xmlNodeList.Count > position)
        {
          isInteger = int.TryParse(xmlNodeList[position].InnerText, out returnValue);
        }

        returnValue = isInteger ? returnValue : -1;
      }
      return returnValue;
    }


    public int GetIntegerValueFromXml(XmlElement xmlElement)
    {
      var xmlElementString  = xmlElement != null ? xmlElement.InnerText : string.Empty;
      var containsAnInteger = false;
      int integerValueFromXml;      
      containsAnInteger     = int.TryParse(xmlElementString, out integerValueFromXml);

      return integerValueFromXml > 0 ? integerValueFromXml : -1;
    }


    public bool? GetBooleanValueFromXml(string xmlElementName)
    {
      bool? returnValue = null;
      var outValue = false;

      if (TheXmlDocument != null)
      {
        var xmlNodeList = TheXmlDocument.GetElementsByTagName(xmlElementName);

        if (xmlNodeList != null && xmlNodeList.Count >= 0)
        {
          Boolean.TryParse(xmlNodeList[0].InnerText, out outValue);
          returnValue = outValue;
        }
      }         
      return returnValue;
    }

    public bool? GetBooleanValueFromXml(string xmlElementName, int position)
    {
      bool? returnValue = null;
      var outValue = false;

      if (TheXmlDocument != null)
      {
        var xmlNodeList = TheXmlDocument.GetElementsByTagName(xmlElementName);

        if (xmlNodeList != null)
        {
          if (xmlNodeList.Count >= position)
          {
            Boolean.TryParse(xmlNodeList[position].InnerText, out outValue);
            returnValue = outValue;
          }
        }
      }
      return returnValue;
    }


    public bool GetBooleanValueFromXml(XmlDocument xmlDocument, string nodeName)
    {
      XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName(nodeName);
      var booleanValueFromXml = false;
      var valueIsBoolean = false;

      if (xmlNodeList != null && xmlNodeList.Count >= 0)
      {
        valueIsBoolean = xmlNodeList[0].InnerText != null ? Boolean.TryParse(xmlNodeList[0].InnerText, out booleanValueFromXml) : false;
      }

      return booleanValueFromXml;
    }


    public string GetStringValueFromXml(string xmlElementName, int position = 0)
    {
      var returnValue = "XML document is null";

      if (TheXmlDocument != null)
      {
        var xmlNodeList = TheXmlDocument.GetElementsByTagName(xmlElementName);

        if (xmlNodeList == null)
        {
          returnValue = "Node not found";
        }
        else if ((xmlNodeList.Count <= position) || (position < 0))
        {
          returnValue = "Index out of range";
        }
        else
        {
          returnValue = xmlNodeList[position].InnerText;
        }
      }    
      return returnValue;
    }


    public string GetXmlElementInnerText(XmlElement xmlElement)
    {
      return xmlElement != null ? xmlElement.InnerText : string.Empty;
    }

    public XmlDocument OpenXmlDocument(string pathConfigValue)
    {
      var xmlDocumentPath = ConfigHelper.GetConfigValue(pathConfigValue);
      var xmlDocument = new XmlDocument();
      xmlDocument.Load(xmlDocumentPath);
      return xmlDocument;
    }
  }
}

