using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.Scratch
{
	public static class TypeConversionScratch
	{
		public static void	StringToDate()
		{
			var line = "2017-11-27 00:00:00.000 SHR D15178 Total USD Russell-IdealRatings Islamic Global -.280000 1.640000 NULL 23.810000 24.920000 8.520000 11.830000 6.430000";
			var separator = "\t";
			var parts = line.Split(new string[] { separator }, StringSplitOptions.None);


			var dateResult = DateTime.Now;			
			var success = DateTime.TryParse(parts[0], out dateResult);

		}
	}
}
