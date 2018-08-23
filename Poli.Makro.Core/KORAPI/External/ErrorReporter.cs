using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core.KORAPI.External
{
	public class ErrorReporter
	{
		public ErrorReporter()
		{
			KOR.ErrorReporter.Models.Api.OutputType = KOR.ErrorReporter.Models.Api.OutputTypes.Json;
			KOR.ErrorReporter.Models.Api.API_KEY = Configs.API_KEY;
			KOR.ErrorReporter.Models.Api.API_SECRET = Configs.API_SECRET;
		}

		public bool ErrorReport()
		{


			return false;
		}
	}
}
