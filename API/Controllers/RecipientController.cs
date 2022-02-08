using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RecipientController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
