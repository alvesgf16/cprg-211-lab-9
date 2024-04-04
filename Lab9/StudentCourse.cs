using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

public class StudentCourse
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public string CourseId { get; set; }
}
