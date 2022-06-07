using Education_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Data
{
  public class EducationContext : DbContext // Steg 1. ärv från EntityFrameworkCore
  {
    public DbSet<Teacher> Teachers => Set<Teacher>(); // Steg 2. Mappa minnesrepresentationen av läraren till databas.
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Competence> Competences => Set<Competence>();
    public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();
    public DbSet<TeacherCompetence> TeacherCompetences => Set<TeacherCompetence>();

    public EducationContext(DbContextOptions options) : base(options) // Steg 3. Skapa konstruktor för att ta hand om anslutningskonfigurationen
    { 
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Course>()
                .HasKey(c => new { c.Id });

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TeacherCompetence>()
                .HasKey(tc => new { tc.TeacherId, tc.CompetenceId });

            modelBuilder.Entity<TeacherCompetence>()
                .HasOne(tc => tc.Teacher)
                .WithMany(s => s.TeacherCompetences)
                .HasForeignKey(tc => tc.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TeacherCompetence>()
                .HasOne(tc => tc.Competence)
                .WithMany(s => s.TeacherCompetences)
                .HasForeignKey(tc => tc.CompetenceId)
                .OnDelete(DeleteBehavior.SetNull);
        }   
}
}