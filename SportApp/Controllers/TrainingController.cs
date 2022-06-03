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
        }
        [HttpPost]
        /* public IActionResult Post([FromRoute]int userId,TrainingDto dto)//przyjmuje int z parametru z route, i obiekt DTO
         {

             return View();
         }

                 [HttpPost]
         public ActionResult Post([FromRoute] int userId, [FromBody]TrainingDto dto)
         {
             var newTrainingId = _trainingService.Create(userId, dto);
             return Created($"{userId}/training/{newTrainingId}", null);

         */
        [HttpGet("list")]
        public async Task<IActionResult> Index()
        {
            return _context.trainings != null ? //jeśli nie jet puste to zwróć widok do którego wysyłasz listę 
                        View(await _context.trainings.ToListAsync()) :
                        Problem("Entity set 'SportAppDbContext.users'  is null.");
        }



        // GET: training/Create
        [HttpGet("create")]
        public IActionResult Create([FromRoute]int userId)//powinien dawać new userDTO i wszystko w nim zebrać a potem zmapować na inne modele
        {

            return View(new TrainingDto());
        }

        // POST: training/Create

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int userId, [Bind("Name,NumberOfExercises,NumberOfRepeat")] TrainingDto dto)
        {
            var train = _mapper.Map<Training>(dto);
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");
            train.userId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(train);
                await _context.SaveChangesAsync();
                return Redirect("https://localhost:7098/user/2/training/list");
            }
            return BadRequest();
        }







    }
}
