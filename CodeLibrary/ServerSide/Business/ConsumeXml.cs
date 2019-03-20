using CodeLibraryHelpers.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CodeLibrary.ServerSide.Business
{
  public class ConsumeXml
  {

    private string _selectedActionChildElementName;
    private string SelectedActionChildElementName
    {
      get
      {
        var returnValue = string.Empty;
        switch (_selectedActionChildElementName.ToLower())
        {
          case "fundamental":
            returnValue = "rafi";
          break;
          case "standard":
            returnValue = "english";
            break;
          default:
            returnValue = _selectedActionChildElementName;
            break;
        }
        return returnValue;
      }
      set
      {
        _selectedActionChildElementName = value;
      }
    }

    public ConsumeXml()
    {
    }

    public void TraverseTnConfigXml()
    {
      var xmlHelper         = new XmlHelper();      
      var indexName         = "FTSE USA Small Cap Qual/Vol/Yield Factor 3% Capped Index";
      var root              = XElement.Load(ConfigHelper.GetConfigValue("TnConfigPath"));
      var rootElements      = root.Elements();
      var breakOut          = false;
      var indexTemplateName = string.Empty;
      var indexList         = GetListOfChildElements(rootElements, "FTSEindexList", "FTSEindex");

      foreach (var index in indexList)
      {
        if (breakOut == true) break;

        var thisIndexName = index.Element("IndexName");

        foreach (var indexElement in index.Elements())
        {
          if (indexElement.Name == "IndexName")
          {
            if (indexElement.Value.Trim() == indexName)
            {
              breakOut             = true;              
              indexTemplateName    = GetChildElementValue(index, "IndexTemplate");
              var ftseTemplateList = GetListOfChildElements(rootElements, "FTSETemplateList", "Template");
              var element          = GetElementContainingValueFromList(ftseTemplateList, "TemplateName", indexTemplateName);              
              SelectedActionChildElementName       = GetChildElementValue(element, "TextSource");
              break;
            }
          }          
        }
      }      
    }


    private XElement GetElementContainingValueFromList(IEnumerable<XElement> listOfElements, string elementName, string childElementSearchValue)
    {
      var returnElement = new XElement(elementName);

      foreach (var element in listOfElements)
      {        
        var childElementValue = GetChildElementValue(element, elementName);
        if (childElementValue == childElementSearchValue)
        {
          returnElement = element;
          break;
        }
      }

      return returnElement;      
    }

    private IEnumerable<XElement> GetListOfChildElements(IEnumerable<XElement> rootElements, string parentName, string childName)
    {
      var FTSETemplateNode =
         from element in rootElements
         where element.Name == parentName
         select element.Elements(childName);

      var templateList = FTSETemplateNode.FirstOrDefault();

      return templateList;
    }


    private string GetChildElementValue(XElement parentElement, string chileElementName)
    {
      var childElementList =
        from element in parentElement.Elements()
        where element.Name == chileElementName
        select element;
      return childElementList.FirstOrDefault().Value.Trim();
    }


    //private XElement GetChildElement(XElement parentElement, string chileElementName)
    //{
    //  var childElementList =
    //    from element in parentElement.Elements()
    //    where element.Name == chileElementName
    //    select element;
    //  return childElementList.FirstOrDefault();
    //}

    public void UseXmlHelper()
    {
      var xmlHelper    = new XmlHelper();
      var xmlDocument = xmlHelper.GetXmlDocument(ConfigHelper.GetConfigValue("XmlDocumentPath"));
      xmlHelper = new XmlHelper(xmlDocument);
      var integerValue = xmlHelper.GetIntegerValueFromXml("NodeContainingIntegerValue");
      integerValue     = xmlHelper.GetIntegerValueFromXml("NodeContainingIntegerValue", 3);
      var booleanValue = xmlHelper.GetBooleanValueFromXml("NodeContainingBooleanValue");
      booleanValue = xmlHelper.GetBooleanValueFromXml("NodeContainingBooleanValue", 2);
      var stringValue = xmlHelper.GetStringValueFromXml("NodeContainingStringValue");
      stringValue = xmlHelper.GetStringValueFromXml("NodeContainingStringValue", 3);
    }    
  }
}
