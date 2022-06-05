using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using SportApp.Models;
using SportApp.Services;

namespace SportApp.Controllers
{
    [Route("/user/{userId}/training/Exercise")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IExerciseService _exerciseService;

        public ExerciseController(SportAppDbContext context, IMapper mapper, ITrainingService exerciseService)
        {
            _context = context;
            _mapper = mapper;
            _exerciseService = exerciseService;
        }

    }
}
