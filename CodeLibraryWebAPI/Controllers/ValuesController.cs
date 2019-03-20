using CodeLibraryDataModels;
using CodeLibraryHelpers.Helpers;
using CodeLibraryDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using static CodeLibraryHelpers.Enums;

namespace CodeLibraryWebAPI.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		//public HttpResponseMessage Get()
		//{
			//var contentId                             = 912222;
			//var techNotice                            = DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), contentId); // "SERVER=ra-stes-sql02\\instance01;DATABASE=APPSETTINGS;integrated security=sspi"
			//var tempLocalPath                         = $"C:\\Temp\\{techNotice.Id}.pdf";	
			//File.WriteAllBytes(tempLocalPath, techNotice.PdfContent);
			//var result                                = new HttpResponseMessage(HttpStatusCode.OK);
			//var stream                                = new FileStream(tempLocalPath, FileMode.Open, FileAccess.Read); 
			//result.Content                            = new StreamContent(stream);
			//result.Content.Headers.ContentType        = new MediaTypeHeaderValue("application/pdf");
			//result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
			//{
			//	FileName = $"{techNotice.Id}.pdf"
			//};

			//return result;
		//}

		// GET api/values/5
		public HttpResponseMessage Get(int id, TnAttachmentType tnAttachmentType)
		{
			var result = new HttpResponseMessage();
			

			try
			{
				var techNotice = DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), id);				
				var stream = new MemoryStream();
				var filename = string.Empty;
				var contentType = new MediaTypeHeaderValue("application/pdf");				

				switch (tnAttachmentType)
				{
					case TnAttachmentType.Content:
						stream = new MemoryStream(techNotice.Content);
						result.Content = new StreamContent(stream);						
						filename = $"{techNotice.Id}_Content.pdf";
						break;
					case TnAttachmentType.ContentItem:
						stream = new MemoryStream(techNotice.ContentItem);
						result.Content = new StreamContent(stream);						
						filename = $"{techNotice.Id}_ContentItem.pdf";
						break;
					case TnAttachmentType.CsvContent:
						stream = new MemoryStream(techNotice.CsvContent);
						result.Content = new StreamContent(stream);
						//contentType = new MediaTypeHeaderValue("application/csv");
						//filename = $"{techNotice.Id}CsvContent.csv";
						filename = $"{techNotice.Id}CsvContent.pdf";
						break;
					case TnAttachmentType.RedactedContent:
						stream = new MemoryStream(techNotice.RedactedContent);
						result.Content = new StreamContent(stream);						
						filename = $"{techNotice.Id}_RedactedContent.pdf";
						break;
					default:
						break;
				}

				result.Headers.AcceptRanges.Add("bytes");
				result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); ;
				result.Content.Headers.ContentType = contentType;
				result.Content.Headers.ContentDisposition.FileName = filename;
				
				

				result.Content.Headers.ContentLength = stream.Length;
			}
			catch (Exception ex)
			{
				result.StatusCode = HttpStatusCode.InternalServerError;
			}

			return result;
		}


		//Working

		// Create and download temp file
		//public HttpResponseMessage Get(int id, TnAttachmentType tnAttachmentType)
		//{

		//	var techNotice = DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), id); // "SERVER=ra-stes-sql02\\instance01;DATABASE=APPSETTINGS;integrated security=sspi"
		//	var tempLocalPath = $"C:\\Temp\\{techNotice.Id}.pdf";

		//	//var byteArrayContent = new ByteArrayContent(techNotice.Content);
		//	var memoryStream = new MemoryStream(techNotice.Content);

		//	File.WriteAllBytes(tempLocalPath, techNotice.Content);
		//	var result = new HttpResponseMessage(HttpStatusCode.OK);

		//	var stream = new FileStream(tempLocalPath, FileMode.Open, FileAccess.Read);

		//	result.Content = new StreamContent(stream);
		//	result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
		//	result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
		//	{
		//		FileName = $"{techNotice.Id}.pdf"
		//	};

		//	return result;
		//}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
