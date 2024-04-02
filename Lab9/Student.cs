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

    public Student() { }

    public override string ToString() => $"Id: {Id}\t\t" +
                                         $"Name: {Name}\t\t" +
                                         $"Email: {Email}\t\t" +
                                         $"Address: {Address}\t\t";
}
