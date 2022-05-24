using Education_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Data
{
  public class EducationContext : DbContext // Steg 1. ärv från EntityFrameworkCore
  {
    public DbSet<Teacher> Teacher => Set<Teacher>(); // Steg 2. Mappa minnesrepresentationen av läraren till databas.
    public DbSet<Category> Category => Set<Category>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Course> Course => Set<Course>();
    public DbSet<StudentCourse> StudentCourse => Set<StudentCourse>();

    public EducationContext(DbContextOptions options) : base(options) // Steg 3. Skapa konstruktor för att ta hand om anslutningskonfigurationen
    {
    }

    public DbSet<Student> Student => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }   
}
}