namespace SportApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // wymagany bo potem będzie to login , potem do dodania też  hasło


        
        /*
        public enum Purpose
        {
            mass,
            reduction,
            strength_increase
        }
        public Purpose purpose { get; set; }

        public enum ActivityLevel : ushort
        {
            small = 1,
            medium = 2,
            big = 3
        }
        public ActivityLevel activityLevel { get; set; }
        */

        public DateTime Created { get; set; } = DateTime.Now;
        public virtual Training? Training { get; set; }
        public virtual ListOfParameters? Parameters { get; set; }
    }
}
