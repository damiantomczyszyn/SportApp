namespace SportApp.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // wymagany bo potem będzie to login , potem do dodania też  hasło
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }

        public string PostalCode { get; set; }

        public  Training Training { get; set; }
        public  ListOfParameters Parameters { get; set; }
    }
}
