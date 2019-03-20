﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibraryDataModels
{
    public class TechNotice
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public byte[] Content { get; set; }
		public byte[] ContentItem { get; set; }
		public byte[] CsvContent { get; set; }
		public byte[] RedactedContent { get; set; }


	}
}
