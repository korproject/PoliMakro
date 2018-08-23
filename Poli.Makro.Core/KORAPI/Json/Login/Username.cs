
namespace Poli.Makro.Core.Json.Login1
{

    public class RootobjectforUsername
    {
        public int code { get; set; }
        public Result result { get; set; }
        public Messages messages { get; set; }
        public Developer_Tips developer_tips { get; set; }
    }

    public class Result
    {
        public string userid { get; set; }
        public string username { get; set; }
    }
}
