namespace SportApp.Models
{
    public class ListOfParameters
    {
        public int Id { get; set; }
       // public int UserId { get; set; }
        public float Weight { get; set; } // w kg do 10 zaokr
        public int Tall { get; set; } //w cm
        public int MaxHeartRate { get; set; }
        //mozna będzie dodać obwody poniżej i jakieś % tkanki tłuszczowej

       // public float? Bmi { get; set; }
       // public int? ActivityLevel { get; set; }

    }
}
