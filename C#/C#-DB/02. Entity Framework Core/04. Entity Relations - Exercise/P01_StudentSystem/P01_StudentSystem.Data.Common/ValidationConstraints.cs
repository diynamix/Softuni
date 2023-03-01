namespace P01_StudentSystem.Data.Common;

public class ValidationConstraints
{
    // Student
    public const int StudentNameMaxLength = 100;
    public const int StudentPhoneNumberMaxLength = 10;

    // Course
    public const int CourseNameMaxLength = 80;
    public const int CourseDescriptionMaxLength = 1000;

    // Resource
    public const int ResourceNameMaxLength = 50;
    public const int ResourceUrlMaxLength = 150;
}