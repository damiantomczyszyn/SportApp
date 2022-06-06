using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using SportApp.Models;

namespace SportApp.Services
{
    public interface IExerciseService
    {
        int Create(int userId, ExerciseDto dto);
        ExerciseDto GetById(int userId, int exerciseId);
        List<ExerciseDto> GetAll(int userId);
    }

    public class ExerciseService : IExerciseService
    {
     
        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;
        public ExerciseService(SportAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int userId, ExerciseDto dto)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");
            var training = _context.trainings.FirstOrDefault(u => u.userId == userId);
            if (training is null)
                throw new Exception("Training not Found");

            
            Exercise exercise = _mapper.Map<Exercise>(dto);
            exercise.TrainingId = training.Id;
            _context.exercises.Add(exercise);
            _context.SaveChanges();

            return exercise.Id;
        }
        public ExerciseDto GetById(int userId, int exerciseId)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");
            var training = _context.trainings.FirstOrDefault(u => u.userId == userId);
            if (training is null)
                throw new Exception("Training not Found");

            var exercise = _context.exercises.FirstOrDefault(d => d.Id == exerciseId);
            if (exercise is null)
                throw new Exception("Exercise not Found");

            var exerciseDto = _mapper.Map<ExerciseDto>(exercise);

            return exerciseDto;
        }

        public List<ExerciseDto> GetAll(int userId)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");
            var training = _context
                .trainings
                .Include(r=>r.Exercise)
                .FirstOrDefault(r => r.userId==userId);


            if (training is null)
                throw new Exception("Training not Found");


            var exercisesDto = _mapper.Map<List<ExerciseDto>>(training.Exercise);

            return exercisesDto;
        }

    }
}
