using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIS341_lab3.Pages
{
    public class StatusCodeModel : PageModel
    {

        private readonly ILogger<StatusCodeModel> _logger;

        public StatusCodeModel(ILogger<StatusCodeModel> logger)
        {
            _logger = logger;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public void OnGet(int code)
        {
            StatusCode = code;

            var userAgent = Request.Headers["User-Agent"].ToString();
            var requestedUrl = HttpContext.Request.Path;


            if (StatusCode == 404)
            {
                Message = "Sorry, the page you requested could not be found.";
                _logger.LogWarning($"404 Not Found. User-Agent: {userAgent}, Requested URL: {requestedUrl}");
            }

            else
            {
                Message = $"An error occurred: {StatusCode}";
                _logger.LogError($"Error {StatusCode}. User-Agent: {userAgent}, Requested URL: {requestedUrl}");
            }
        }
    }
}
