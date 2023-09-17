using System.Collections.Generic;

namespace WebApplication19.Model
{
    public class Data
    {
        public static Dictionary<string, string> Users = new Dictionary<string, string>
        {
            {"SampleUser","Password" },
            {"DemoUser","Password" }
        };
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
