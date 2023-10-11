using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication2.Controllers
{
    public class FAQController : Controller
    {
        // Path: /FAQ or /FAQ/Index  <----- Convention over configuration
        public IActionResult Index() 
        {
            return View();
        }

        //Path: /FAQ/Item/1
        //Path: /FAQ/Item?ID=3
        public string Item(int ID = 1)
        {
            return $"Item {ID}";
        }
    }
}
