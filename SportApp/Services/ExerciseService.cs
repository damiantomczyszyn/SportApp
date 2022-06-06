using AutoMapper;
using SportApp.Entities;
using SportApp.Models;

namespace SportApp.Services
{
    public interface IExerciseService
    {
        int Create(int userId, ExerciseDto dto);
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

            var trainingEntity = _mapper.Map<Training>(dto);

            trainingEntity.userId = userId;

            _context.trainings.Add(trainingEntity);
            _context.SaveChanges();

            return 0;
        }

    }
}
