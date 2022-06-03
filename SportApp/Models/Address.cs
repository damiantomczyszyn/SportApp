namespace SportApp.Models
{
    public class Address
    {
        public int Id { get; set; }// dodaj numer domu
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }//popraw na country

        public string PostalCode { get; set; }
        public virtual User User { get; set; }
    }
}
