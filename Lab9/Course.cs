using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

public class Course
{
    [Required]
    [PrimaryKey]
    public string CourseId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Credits { get; set; }

    public Course() { }

    public override string ToString() => $"Course ID: {CourseId}\t\t"
                                         + $"Name: {Name}\t\t"
                                         + $"Number of Credits: {Credits}\t\t";
}
