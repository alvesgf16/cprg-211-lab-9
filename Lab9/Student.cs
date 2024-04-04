using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

public class Student
{
    [Required]
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    public string Address { get; set; }

    [Ignore] // This attribute tells SQLite to ignore this property during database operations
    public List<Course> Courses { get; set; } = [];

    public override string ToString() => $"Id: {Id, -2}\t\t" +
                                         $"Name: {Name, -18}\t\t" +
                                         $"Email: {Email, -21}\t\t" +
                                         $"Address: {Address}\t\t";
}
