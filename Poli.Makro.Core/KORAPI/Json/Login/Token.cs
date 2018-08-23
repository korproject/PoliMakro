namespace Poli.Makro.Core.Json.Login1
{
	public class RootobjectforToken 
	{
		public int code { get; set; }
		public string result { get; set; }
		public Messages messages { get; set; }
		public Dev_Tips dev_tips { get; set; }
	}

	public class Dev_Tips
	{
		public string tip { get; set; }
		public string link { get; set; }
	}
}
