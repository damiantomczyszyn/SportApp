using AutoMapper;
using SportApp.Entities;
using SportApp.Models;
//using SportApp.Exceptions;

namespace SportApp.Services
{
    public interface ITrainingService
{
    int Create(int userId, TrainingDto dto);
}


    public class TrainingService : ITrainingService
    {
        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;
        public TrainingService(SportAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int userId, TrainingDto dto)
        { 
            var user = _context.users.FirstOrDefault(u=>u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");

            var trainingEntity = _mapper.Map<Training>(dto);

            trainingEntity.userId = userId;

            _context.trainings.Add(trainingEntity);
            _context.SaveChanges();
            return trainingEntity.Id;
        }

        public int GetAll(int userId, TrainingDto dto)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");

            var trainingEntity = _mapper.Map<Training>(dto);

            trainingEntity.userId = userId;

            _context.trainings.Add(trainingEntity);
            _context.SaveChanges();
            return trainingEntity.Id;
        }

    }
}
