using Microsoft.EntityFrameworkCore;
using SportApp.Models;

namespace SportApp.Entities//To undo this action, use Remove-Migration.
{
    public class SportAppDbContext : DbContext
    {
        private string _connectionString = "server=REBOOTX;Database=SportApps;Trusted_Connection=True;";
        public DbSet<User> users { get; set; }
        public DbSet<Training> trainings { get; set; }

        public DbSet<ListOfParameters> parameters { get; set; }
        public DbSet<Exercise> exercises { get; set; }
        
        public DbSet<Address> addresses { get; set; }
        //public DbSet<Dish> dishes { get; set; }
        // public DbSet<Diet> diets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)// tu określamy co jest wymagane a co nie
        {
            modelBuilder.Entity<User>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<User>()
                .Property(r => r.Email)
                .IsRequired()                
                .HasMaxLength(36);
            modelBuilder.Entity<Address>()
                .Property(r => r.City)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(r => r.Street)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(r => r.PostalCode)
                .IsRequired();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
