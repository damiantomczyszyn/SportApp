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
                new User(){ Name="Zygfryd", Age=21,LastName="Mabenz",
                Email="Mabenz@o2.pl",
                Training = new Training()
                {
                  Description= "Ćwiczenie nr 1",
                  PauseBetweenReps = 3,
                  BreakTimeBetweenEx = 4,
                },
                Address = new Address()
                { City = "Lublin",
                  Street = "Spacerowa",
                  PostalCode="21-555",
                  Country="Polska"},
                Parameters = new ListOfParameters()
                {
                    Weight = 80,
                    Tall = 180,
                    MaxHeartRate = 200,
                }
                },
                new User(){ Name="Zygfrydo", Age=39,LastName="Don Mabenz",
                Email="Mabenzo@o2.pl"},
                new User(){ Name="Kasijaso", Age=100,LastName="Gkeeper",
                Email="GKasi@o2.pl"},
                new User(){ Name="Kristiano", Age=18,LastName="Rolando",
                Email="KaRol@o2.pl"}
            };
            return users;

        }
           
    }
}

