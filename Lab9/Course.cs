using System.ComponentModel.DataAnnotations;

using SQLite;

namespace Lab9;

public class Course
{
    [Required]
    [PrimaryKey]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Credits { get; set; }

    public override string ToString() => $"Course ID: {Id}\t\t"
                                         + $"Name: {Name, -42}\t\t"
                                         + $"Number of Credits: {Credits}\t\t";
}
