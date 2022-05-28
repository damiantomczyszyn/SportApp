using SportApp.Entities;
using SportApp.Models;

namespace SportApp
{
    public class SportAppSeeder
    {
        private readonly SportAppDbContext _dbContext;
        public SportAppSeeder(SportAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.users.Any())
                {
                    var users = GetUsers();
                    _dbContext.users.AddRange(users);
                    _dbContext.SaveChanges(); //zapis zmian na kontekście bazydanych
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User(){ },
                new User(){ }
            };
            return users;

        }
           
    }
}

