using System.Net;

namespace Poli.Makro.Core.Controllers
{
	public class ServerController
	{
		public static bool ServerControl()
		{
			try
			{
				using (var webClient = new WebClient())
				{
					using (webClient.OpenRead("http://api.kor.onl/"))
					{
						return true;
					}
				}
			}
			catch { }

			return false;
		}
	}
}
