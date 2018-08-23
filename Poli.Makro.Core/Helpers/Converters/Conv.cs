using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core
{
	public class Conv
	{
		/// <summary>
		/// Int custom tryParser
		/// </summary>
		/// <param name="value">string numeric value</param>
		/// <param name="defaultValue"></param>
		/// <param name="minValue"></param>
		/// <param name="maxValue"></param>
		/// <returns></returns>
		public static int Int(string value, int defaultValue = 0, int minValue = int.MinValue, int maxValue = int.MaxValue)
		{
			int output = int.TryParse(value, out output) ? output : defaultValue;

			output = output < minValue ? defaultValue : output;
			output = output > maxValue ? defaultValue : output;

			return output;
		}

		public static double Double(string value, double defaultValue = 0, double minValue = double.MinValue, double maxValue = double.MaxValue)
		{
			double output = double.TryParse(value, out output) ? output : defaultValue;

			output = output < minValue ? defaultValue : output;
			output = output > maxValue ? defaultValue : output;

			return output;
		}
	}
}
