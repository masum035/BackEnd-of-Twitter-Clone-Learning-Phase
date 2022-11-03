using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TweeterBackend.ModelBinding
{
    public class CustomBinding
    {
        [FromQuery] public int Id { get; set; }

        [FromHeader(Name = "cookie")] public string HelpCookie { get; set; }

        [BindProperty(SupportsGet = true, Name = "AllRight")]
        public bool AllRight { get; set; }

        // public Dictionary<string, string> Locations { get; set; }
    }
}