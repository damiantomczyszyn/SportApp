using AutoMapper;
using SportApp.Entities;
using SportApp.Models;
//using SportApp.Exceptions;

namespace SportApp.Services
{
    public interface ITrainingService
{
    int Create(int userId, TrainingDto dto);
    Training GetTrainingById(int userId);
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
            user.TrainingId = trainingEntity.Id;
            trainingEntity.userId = userId;

            _context.trainings.Add(trainingEntity);
            _context.SaveChanges();
            return trainingEntity.Id;
        }

        public TrainingDto GetById(int userId, int trainingId)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");

            var training = _context.trainings.FirstOrDefault(u => u.Id == trainingId);

            if(training is null || training.userId != userId)
            { throw new Exception("training not found"); }
            
            var trainingDto = _mapper.Map<TrainingDto>(training);

           
            return trainingDto;
        }

        public Training GetTrainingById(int userId)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not Found");

            var training = _context.trainings.FirstOrDefault(u => u.userId == userId);

            if (training is null || training.userId != userId)
            { throw new Exception("training not found"); }

         return training;
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
