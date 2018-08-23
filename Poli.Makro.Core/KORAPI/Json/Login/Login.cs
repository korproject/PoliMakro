using Poli.Makro.Core.Json.Login1;

namespace Poli.Makro.Core.Json.Login2
{

	public class RootobjectforLogin
	{
		public int code { get; set; }
		public Result result { get; set; }
		public Messages messages { get; set; }
	}

	public class Result
	{
		public string userid { get; set; }
		public string username { get; set; }
		public string user_image { get; set; }
		public string token { get; set; }
		public string expire { get; set; }
	}
}
