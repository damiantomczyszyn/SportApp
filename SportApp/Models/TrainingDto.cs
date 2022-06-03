namespace SportApp.Models
{
    public class TrainingDto
    {
        public string? Description { get; set; }// Opis do wyświetlenia przy widoku treningu

       
        public int PauseBetweenReps { get; set; }//w sekundach int
        public int BreakTimeBetweenEx { get; set; }// w sekundach int

    }
}
