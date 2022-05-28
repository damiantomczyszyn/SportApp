using Microsoft.AspNetCore.Mvc;

namespace SportApp.Controllers
{
    [Route("api/{userId}/training")]
    [ApiController]
    public class TrainingController : Controller
    {
       [HttpPost]
        public IActionResult Post([FromRoute]int userId, CreateTraining dto)
        {
            return View();
        }
    }
}
