using SportApp.Models;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using AutoMapper;
namespace SportApp.Services
{
    public class UserService
    {
        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(SportAppDbContext context, IMapper  mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserDto GetById(int id)
        {

            var user =  _context
                .users
                .Include(r => r.Address)
                .Include(r => r.Training)
                .FirstOrDefaultAsync(m => m.Id == id);
            if( user is null) return null;
            var result = _mapper.Map<UserDto>(user);
            return result;
        }
        public IEnumerable<UserDto>GetAll()
        {
            var users = _context
            .users
            .Include(r => r.Address)
            .Include(r => r.Training)
            .ToList();
        
            var restuarantDtos = _mapper.Map<List<UserDto>>(users);
            return restuarantDtos;
        }
        public void Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _context.users.Add(user);
            _context.SaveChanges();
        }
        
    
    }
}
