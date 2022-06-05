using Microsoft.AspNetCore.Mvc;

namespace SportApp.Controllers
{
    public class ExerciseController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
