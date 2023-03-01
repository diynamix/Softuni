namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using Common;

public class Course
{
    public Course()
    {
        StudentsCourses = new HashSet<StudentCourse>();

        Resources = new HashSet<Resource>();

        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int CourseId { get; set; }

    //[Required]
    [MaxLength(ValidationConstraints.CourseNameMaxLength)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    //[MaxLength(ValidationConstraints.CourseDescriptionMaxLength)]
    [Unicode(true)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}