namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using Common;

public class Student
{
    public Student()
    {
        StudentsCourses = new HashSet<StudentCourse>();

        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    //[Required]
    [MaxLength(ValidationConstraints.StudentNameMaxLength)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    //[StringLength(10, MinimumLength = 10)]
    [MaxLength(ValidationConstraints.StudentPhoneNumberMaxLength)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}