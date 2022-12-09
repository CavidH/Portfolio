using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return Content("ok");
        }
    }
}
