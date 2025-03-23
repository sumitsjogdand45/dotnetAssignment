using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
