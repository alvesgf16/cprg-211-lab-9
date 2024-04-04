using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

/// <summary>
/// Represents the relationship between students and courses in the educational system.
/// </summary>
public class StudentCourse
{
    /// <summary>
    /// The unique identifier of the student-course relationship.
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    /// <summary>
    /// The ID of the student associated with the relationship.
    /// </summary>
    [Required]
    public int StudentId { get; set; }

    /// <summary>
    /// The ID of the course associated with the relationship.
    /// </summary>
    [Required]
    public string CourseId { get; set; }
}