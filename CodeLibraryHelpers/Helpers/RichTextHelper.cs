using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CodeLibraryHelpers.Helpers
{
  public static class RichTextHelper
  {
    public static string RichTextPath
    {
      get
      {
        return ConfigHelper.GetConfigValue("RichTextFilePath");
      }
    }
    
    public static string GetTextFromRichTextFile()
    {      
      var richText = File.ReadAllText(RichTextPath);
      
      return richText;
    }
  }
}
