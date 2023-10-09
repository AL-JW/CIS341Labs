using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

namespace CIS341_lab3.Pages.About
{
    public class ThanksModel : PageModel
    {
        private readonly LinkGenerator _linkGenerator;

        public string ContactLink { get; set; }

        public ThanksModel(LinkGenerator linkGenerator)
        {

            _linkGenerator = linkGenerator;

        }

        public void OnGet()
        {

            //Needed to use /About/Contact instead of /Contact to get the link to work. 
            ContactLink = _linkGenerator.GetPathByPage("/About/Contact");

        }
    }
}
