using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

/// <summary>
/// Represents a course within the educational system.
/// </summary>
public class Course
{
    /// <summary>
    /// The unique identifier of the course.
    /// </summary>
    [Required]
    [PrimaryKey]
    public string Id { get; set; }

    /// <summary>
    /// The name of the course.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// The number of credits associated with the course.
    /// </summary>
    [Required]
    public int Credits { get; set; }

    /// <summary>
    /// A string representation of the course.
    /// </summary>
    /// <returns>
    /// A string containing the course ID, name, and number of credits.
    /// </returns>
    public override string ToString() => $"Course ID: {Id}\t\t"
                                         + $"Name: {Name,-42}\t\t"
                                         + $"Number of Credits: {Credits}\t\t";
}