using CodeLibraryHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeLibrary.ServerSide.Business
{
  public class RichText
  {
    public static string GetPlainTextFromRichTextFile()
    {
      var richText    = RichTextHelper.GetTextFromRichTextFile();
      var richTextBox = new RichTextBox();
      richTextBox.Rtf = richText;
      var plainText   = richTextBox.Text;

      return plainText;
    }
  }
}
