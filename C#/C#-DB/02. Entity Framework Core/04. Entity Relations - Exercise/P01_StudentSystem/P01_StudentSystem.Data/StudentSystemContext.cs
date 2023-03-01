namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;

using Common;
using Models;

public class StudentSystemContext : DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Homework> Homeworks { get; set; } = null!;
    public DbSet<Resource> Resources { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    protected StudentSystemContext()
    {
    }

    public StudentSystemContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }

        //base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasMany(s => s.StudentsCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            entity
                .HasMany(s => s.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity
                .HasMany(c => c.StudentsCourses)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            entity
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            entity
                .HasMany(c => c.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);
        });
    }
}