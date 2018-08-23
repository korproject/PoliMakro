namespace Poli.Makro.Core.Json.Login1
{
    public class Messages
    {
        public bool error { get; set; }
        public string error_message { get; set; }
        public bool warning { get; set; }
        public string warning_message { get; set; }
    }

    public class Developer_Tips
    {
        public int severity { get; set; }
        public string message { get; set; }
        public string help_link { get; set; }
    }
}
