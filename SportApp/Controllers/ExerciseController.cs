using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using SportApp.Models;
using SportApp.Services;

namespace SportApp.Controllers
{
    [Route("/user/{userId}/training/exercise")]//każdy ma 1 trening więc bez id treningu po prostu od usera
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IExerciseService _exerciseService;

        public ExerciseController(SportAppDbContext context, IMapper mapper, IExerciseService exerciseService)
        {
            _context = context;
            _mapper = mapper;
            _exerciseService = exerciseService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int userId,[FromBody] ExerciseDto dto)
        {
            var newExId = _exerciseService.Create(userId, dto);
            return Created($"/user/{userId}/training/exercise{newExId}",null);
        }
        [HttpGet("list")]
        public async Task<IActionResult> Index()
        {
            return _context.exercises != null ? //jeśli nie jet puste to zwróć widok do którego wysyłasz listę 
                        View(await _context.exercises.ToListAsync()) :
                        Problem("Entity set 'SportAppDbContext.users'  is null.");
        }
        [HttpGet("{exerciseId}")]
        public ActionResult<ExerciseDto> Get([FromRoute] int userId, [FromRoute] int exerciseId)
        {
            ExerciseDto exercise = _exerciseService.GetById(userId, exerciseId);

            return Ok(exercise);
        }
        [HttpGet]
        public ActionResult<List<ExerciseDto>> Get([FromRoute] int userId)
        {
            List<ExerciseDto> result = _exerciseService.GetAll(userId);

            return Ok(result);
        }
    }
}
