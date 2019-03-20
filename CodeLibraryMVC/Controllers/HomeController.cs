using ClassLibraryDatModels;
using CodeLibraryDataLayer;
using CodeLibraryHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CodeLibraryHelpers.Enums;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using CodeLibraryHelpers.ExtensionMethods;


namespace CodeLibraryMVC.Controllers
{
  public class HomeController : Controller
  {
		//[HttpPost]

		private static readonly HttpClient client = new HttpClient();

		public void PostEmailPreferences(EmailPreferencesFormData emailPreferencesFormData)
		{
			SendEmailPreferencesPost(emailPreferencesFormData);
		}
		
		private async Task<string> SendEmailPreferencesPost(EmailPreferencesFormData emailPreferencesFormData)
		{
			var responseString = string.Empty;
			
			try
			{
				var emailNameValuePairs = new Dictionary<string, string>();
				var properties          = typeof(EmailPreferencesFormData).GetProperties();

				foreach (var property in properties)
				{					
					var fieldName  = emailPreferencesFormData.GetType().GetProperty(property.Name).GetValue(emailPreferencesFormData, null)?.ToString().Split('#')[1];
					var fieldValue = emailPreferencesFormData.GetType().GetProperty(property.Name).GetValue(emailPreferencesFormData, null)?.ToString().Split('#')[0];
					emailNameValuePairs.Add(fieldName, fieldValue);					
				}
								
				var content           = new FormUrlEncodedContent(emailNameValuePairs);
				var preferenceFormUrl = ConfigHelper.GetConfigValue("PreferenceFormUrl");
				var response          = await client.PostAsync(preferenceFormUrl, content);
				responseString        = await response.Content.ReadAsStringAsync();				
			}
			catch (Exception ex)
			{ }

			return responseString;
		}

		private async Task<string> SendEmailPreferencesPostOLD(EmailPreferencesFormData emailPreferencesFormData)
		{
			var responseString = string.Empty;
			var preferenceFormFieldNames = ConfigHelper.GetConfigValue("PreferenceFormFieldNames").Split(',');

			try
			{
				var emailNameValuePairs   = new Dictionary<string, string>();
				var properties = typeof(EmailPreferencesFormData).GetProperties();

				foreach (var property in properties)
				{
					foreach (var field in preferenceFormFieldNames)
					{
						var fieldNameAlias = field.Split('=')[0];
						var fieldName      = field.Split('=')[1];

						if (property.Name == fieldNameAlias)
						{
							emailNameValuePairs.Add(fieldName, emailPreferencesFormData.GetType().GetProperty(property.Name).GetValue(emailPreferencesFormData, null)?.ToString());
						}
					}
				}

				//foreach (PropertyInfo property in properties)
				//{
				//	var propertyName = property.Name.TrimCharsFromString(1, StartOrEnd.Start);
				//	propertyName     = propertyName == "6522_388844pi_6522_388844" ? propertyName : $"{propertyName}[]";
				//	emailNameValuePairs.Add(propertyName, emailPreferencesFormData.GetType().GetProperty(property.Name).GetValue(emailPreferencesFormData, null)?.ToString());
				//}

				var content           = new FormUrlEncodedContent(emailNameValuePairs);
				var preferenceFormUrl = ConfigHelper.GetConfigValue("PreferenceFormUrl");
				//var response          = await client.PostAsync(preferenceFormUrl, content);
				//responseString        = await response.Content.ReadAsStringAsync();				
			}
			catch(Exception ex)
			{ }

			return responseString;
		}

		// GET: Home
		public ActionResult Index()
    {
			ViewBag.Title		= "Home Page";
			var techNotice	= CodeLibraryDataLayer.DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), 912222);
			
			return View(techNotice);
    }


		public FileResult GetPdfFile(int id, TnAttachmentType tnAttachmentType)
		{			
			//Inject file byte array http response
			var techNotice         = DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), id);
			var filename           = $"{techNotice.Id}_{tnAttachmentType}.pdf";
			FileContentResult file = null;

			switch (tnAttachmentType)
			{
				case TnAttachmentType.Content:
					file = File(techNotice.Content, MimeTypes.pdf.ToString(), filename);
					break;
				case TnAttachmentType.ContentItem:
					file = File(techNotice.Content, MimeTypes.pdf.ToString(), filename);
					break;
				case TnAttachmentType.CsvContent:
					file = File(techNotice.Content, MimeTypes.pdf.ToString(), filename);
					break;
				case TnAttachmentType.RedactedContent:
					file = File(techNotice.Content, MimeTypes.pdf.ToString(), filename);
					break;
				default:
					break;
			}				
									
			return file;
		}


		public ActionResult Idio()
		{
			ViewBag.Title = "Idio";
			
			return View();
		}

		public FileResult GetPdfFileDownloadTempFile(int id, TnAttachmentType tnAttachmentType)
		{
			//Write physical file and inject in to http response
			var techNotice = DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), id);
			var filename = $"{techNotice.Id}_{tnAttachmentType}.pdf";
			var tempLocalPath = $"C:\\Temp\\{filename}";

			switch (tnAttachmentType)
			{
				case TnAttachmentType.Content:					
					System.IO.File.WriteAllBytes(tempLocalPath, techNotice.Content);
					break;
				case TnAttachmentType.ContentItem:					
					System.IO.File.WriteAllBytes(tempLocalPath, techNotice.ContentItem);
					break;
				case TnAttachmentType.CsvContent:					
					System.IO.File.WriteAllBytes(tempLocalPath, techNotice.CsvContent);
					break;
				case TnAttachmentType.RedactedContent:					
					System.IO.File.WriteAllBytes(tempLocalPath, techNotice.RedactedContent);
					break;
				default:
					break;
			}

			var pdfFileInfo = new FileInfo(tempLocalPath);
			return File(techNotice.Content, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
		}


		//public FileResult GetPdfFile(int id, TnAttachmentType tnAttachmentType)
		//{
		//	var techNotice    = DataAccess.GetPdfFromDatabase(ConfigHelper.GetConnectionString("APPSETTINGSConnectionString"), id);
		//	var tempLocalPath = $"C:\\Temp\\{techNotice.Id}.pdf";
		//	System.IO.File.WriteAllBytes(tempLocalPath, techNotice.Content);
		//	var pdfFileInfo   = new FileInfo(tempLocalPath);

		//	return File(techNotice.Content, System.Net.Mime.MediaTypeNames.Application.Octet, $"{techNotice.Id}.pdf");			
		//}
	}
}