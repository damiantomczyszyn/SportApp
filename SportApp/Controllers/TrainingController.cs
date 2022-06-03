using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using SportApp.Models;
namespace SportApp.Controllers
{
    [Route("api/{userId}/training")]
    [ApiController]//wszystkie modele zostały automatycznie zwalidowane dla każdej akcji
    public class TrainingController : Controller
    {

        private readonly SportAppDbContext _context;

        public TrainingController(SportAppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post([FromRoute]int userId,Training training)//przyjmuje int z parametru z route, i obiekt DTO
        {

            return View();
        }
        public async Task<IActionResult> Index()
        {
            return _context.trainings != null ? //jeśli nie jet puste to zwróć widok do którego wysyłasz listę 
                        View(await _context.trainings.ToListAsync()) :
                        Problem("Entity set 'SportAppDbContext.users'  is null.");
        }
    }
}
