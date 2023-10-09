using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIS341_lab3.Pages
{
    public class ContactFormData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }


    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormData FormData { get; set; } = new ContactFormData();

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Name: {FormData.Name}, Email: {FormData.Email}, Message: {FormData.Message}");

                return RedirectToPage("Thanks");
            }

            return Page();
        }

        public void OnGet()
        {
        }
    }
}
