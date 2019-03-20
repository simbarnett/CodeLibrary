using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebRequest.Controllers
{
	public class HomeController : Controller
	{
		private static readonly HttpClient client = new HttpClient();
		public async Task<ActionResult> Index()
		{
			var a = await BlahAsync();
			return View();
		}


		public async static Task<string> BlahAsync()
		{
			var emailNameValuePairs = new Dictionary<string, string>();
			emailNameValuePairs.Add("name", "simon");
			var preferenceFormUrl = "http://www2.londonstockexchangegroup.com/l/6522/2017-10-18/3xpc8kXXX";
			var responseString = string.Empty;

			using (var content = new FormUrlEncodedContent(emailNameValuePairs))
			{
				var response = await client.PostAsync(preferenceFormUrl, null);
				responseString = await response.Content.ReadAsStringAsync();
			}

			return responseString;
		}


		public class EmailPreferencesFormData
		{
			public string EmailField { get; set; }
			public string FirstNameField { get; set; }
			public string LastNameField { get; set; }
			public string CompanyNameField { get; set; }
			public string CountryField { get; set; }
			public string ChinaField { get; set; }
			public string EnvironSocGovField { get; set; }
			public string EquityField { get; set; }
			public string FixedIncomeField { get; set; }
			public string RealEstateField { get; set; }
			public string SmartBetaField { get; set; }
			public string EtpField { get; set; }
			public string SmallCapPerspField { get; set; }
			public string ChinaFixedIncField { get; set; }
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}