namespace SportApp.Models
{
    public class Training
    {


        public int Id { get; set; }
        public string? Description { get; set; }// Opis do wyświetlenia przy widoku treningu


        public int PauseBetweenReps { get; set; }//w sekundach int
        public int BreakTimeBetweenEx { get; set; }// w sekundach int

        public virtual List<Exercise>? Exercise { get; set; } // lista ćwiczeń
    }
}
