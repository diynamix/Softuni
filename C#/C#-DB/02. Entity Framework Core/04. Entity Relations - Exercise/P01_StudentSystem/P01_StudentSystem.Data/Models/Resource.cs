﻿namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Common;
using Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    //[Required]
    [MaxLength(ValidationConstraints.ResourceNameMaxLength)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    //[MaxLength(ValidationConstraints.ResourceUrlMaxLength)]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;
}