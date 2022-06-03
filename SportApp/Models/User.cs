namespace SportApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // wymagany bo potem będzie to login , potem do dodania też  hasło 

        public DateTime Created { get; set; } = DateTime.Now;
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        public int? TrainingId { get; set; }//FK for training
        public virtual Training? Training { get; set; }
        public int? ListOfParametersId   { get; set; }
        public virtual ListOfParameters? Parameters { get; set; }
    }
}
