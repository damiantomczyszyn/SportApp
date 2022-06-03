namespace SportApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfExercises { get; set; }

        public int NumberOfRepeat { get; set; }
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}
