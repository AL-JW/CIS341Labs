using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace MyCoreApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        // Property to hold the formatted date string
        public string FormattedDate { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;
        }
    }
}