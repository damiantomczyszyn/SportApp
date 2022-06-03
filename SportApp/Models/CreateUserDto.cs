namespace SportApp.Models
{
    public class CreateUserDto
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // wymagany bo potem będzie to login , potem do dodania też  hasło 

        public DateTime Created { get; set; } = DateTime.Now;
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
