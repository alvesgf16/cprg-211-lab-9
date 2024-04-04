using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

/// <summary>
/// Represents a student in the educational system.
/// </summary>
public class Student
{
    /// <summary>
    /// The unique identifier of the student.
    /// </summary>
    [Required]
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    /// <summary>
    /// The name of the student.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// The email address of the student.
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// The address of the student.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The list of courses associated with the student.
    /// </summary>
    /// <remarks>
    /// This property is ignored during database operations.
    /// </remarks>
    [Ignore]
    public List<Course> Courses { get; set; } = [];

    /// <summary>
    /// A string representation of the student.
    /// </summary>
    /// <returns>A string containing the student's ID, name, email, and address.</returns>
    public override string ToString() => $"Id: {Id, -2}\t\t" +
                                         $"Name: {Name, -18}\t\t" +
                                         $"Email: {Email, -21}\t\t" +
                                         $"Address: {Address}\t\t";
}