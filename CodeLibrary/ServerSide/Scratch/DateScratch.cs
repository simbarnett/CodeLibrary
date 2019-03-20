using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.Scratch
{
	public static class DateScratch
	{
		public static void ConvertDate()
		{
			var dateTimeString = "2017-11-27 00:00:00.000";
			var dateTimeParts = dateTimeString.Split(' ');
			var dateParts = dateTimeParts[0].Split('-');
			var theDate = new DateTime(Convert.ToInt16(dateParts[0]), Convert.ToInt16(dateParts[1]), Convert.ToInt16(dateParts[2]));
			var russellClass = new RussellDataItem();

			var classType = typeof(RussellDataItem);

			var a = theDate.GetType().FullName;
			var b = typeof(RussellDataItem).GetProperties()[0].ToString();

			//foreach (var prop in classType.GetProperties)

			var c = "-.130000";

			if (c.Substring(0,1) == "-")
			{
				c = c.Substring(1, c.Length - 1);
				var e = Convert.ToDecimal(c);
				e = 0 - e;
			}

			var d = (string.IsNullOrEmpty(c) || String.Equals(c, "NULL", StringComparison.InvariantCultureIgnoreCase)) ? (decimal?)null : Convert.ToDecimal(c);

		}
	}

	public class RussellDataItem
	{
		public decimal? ThreeMo { get; set; }

	}

}
