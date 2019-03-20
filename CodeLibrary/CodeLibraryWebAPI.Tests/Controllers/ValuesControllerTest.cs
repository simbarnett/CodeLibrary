using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeLibraryWebAPI;
using CodeLibraryWebAPI.Controllers;
using CodeLibraryDataModels;

namespace CodeLibraryWebAPI.Tests.Controllers
{
	[TestClass]
	public class ValuesControllerTest
	{
		[TestMethod]
		public void Get()
		{
			// Arrange
			ValuesController controller = new ValuesController();

			// Act
			//var result = controller.GetPdfFromDatabase();

			// Assert
			//Assert.IsNotNull(result);
			//Assert.IsTrue(result.Title.ToString() == "Ryman Hospitality Properties (USA): Shares in Issue and Investability Weight Change (Russell Pure Style Index Series)");
			//Assert.IsTrue(result.Id == 912222);
			//Assert.IsNotNull(result.PdfContent);
			
		}

		//[TestMethod]
		//public void GetById()
		//{
		//	// Arrange
		//	ValuesController controller = new ValuesController();

		//	// Act
		//	string result = controller.Get(5);

		//	// Assert
		//	Assert.AreEqual("value", result);
		//}

		[TestMethod]
		public void Post()
		{
			// Arrange
			ValuesController controller = new ValuesController();

			// Act
			controller.Post("value");

			// Assert
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
			ValuesController controller = new ValuesController();

			// Act
			controller.Put(5, "value");

			// Assert
		}

		[TestMethod]
		public void Delete()
		{
			// Arrange
			ValuesController controller = new ValuesController();

			// Act
			controller.Delete(5);

			// Assert
		}
	}
}
