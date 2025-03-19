using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
