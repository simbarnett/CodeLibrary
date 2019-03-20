using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibraryHelpers
{
  public class Enums
  {
    public enum UrlScheme
    {
      http,
      https
    }

		public enum TnAttachmentType
		{
			Content,
			ContentItem,
			CsvContent,
			RedactedContent
		}

		public enum MimeTypes
		{
			pdf,
			xls,
			doc,
			xlsx,
			docx
		}

		public enum StartOrEnd
		{
			Start,
			End
		}
  }
}
