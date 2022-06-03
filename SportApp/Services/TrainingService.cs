using SportApp.Entities;
using SportApp.Models;
//using SportApp.Exceptions;

namespace SportApp.Services
{
    public class TrainingService
    {
        private readonly SportAppDbContext _context;
        public TrainingService(SportAppDbContext context)
        {
            _context = context;
        }
   /*     public int Create(int userId, TrainingDto dto)
        { 
            var user = _context.users.FirstOrDefault(u=>u.Id == userId);
            if (user == null)
                throw new Exception("brak");

            var trainingEntity = _mapper.Map<Training>(dto);
            return Create(user, trainingEntity);
        }*/
    }
}
