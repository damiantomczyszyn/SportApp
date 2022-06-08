using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using SportApp.Models;
using SportApp.Services;

namespace SportApp.Controllers
{
    [Route("/user/{userId}/training")]
    //[Route("/training/")]
    [ApiController]//wszystkie modele zostały automatycznie zwalidowane dla każdej akcji
    public class TrainingController : Controller
    {

        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITrainingService _trainingService;

        public TrainingController(SportAppDbContext context, IMapper mapper, ITrainingService trainingService)
        {
            _context = context;
            _mapper = mapper;
            _trainingService = trainingService;
        }


        [HttpPost]
        public ActionResult Post([FromRoute] int userId, [FromBody] TrainingDto dto)
        {
            var newTrainingId = _trainingService.Create(userId, dto);
            return Created($"{userId}/training/{newTrainingId}", null);
        }

       
        [HttpGet("list")]
        public async Task<IActionResult> Index()
        {
            return _context.trainings != null ? //jeśli nie jet puste to zwróć widok do którego wysyłasz listę 
                        View(await _context.trainings.ToListAsync()) :
                        Problem("Entity set 'SportAppDbContext.users'  is null.");
        }
        [HttpGet]
        public ActionResult<TrainingDto> Get([FromRoute] int userId)
        {
           // var user = _context.users.FirstOrDefault(u => u.Id == userId);
            var training = _context.trainings.FirstOrDefault(t => t.userId == userId);
            return Ok(training);
        }
        [HttpDelete]
        public ActionResult Delete([FromRoute] int userId)
        {
            var training = _trainingService.GetTrainingById(userId);
            _context.trainings.Remove(training);
            _context.SaveChanges();
            return NoContent();
        }







    }
}
