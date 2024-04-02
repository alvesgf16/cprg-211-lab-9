using Lab9;

internal class Program
{
    private static void Main(string[] args)
    {
        StudentManager studentManager = new();

        List<Student> students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        //adding a new student
        Console.WriteLine("\nAdding a new student...");
        Student newStudent = new()
        {
            Name = "Matt Damon",
            Email = "matt@sait.ca",
            Address = "12345 Main Street"
        };
        studentManager.Add(newStudent);
        Console.WriteLine("New student added");

        //updating a student
        Console.WriteLine("\n\nUpdating new Student...");
        Student studentToUpdate = students[9];
        studentToUpdate.Email = "updatedemail@sait.ca";
        studentToUpdate.Address = "updatedAddress 32nd Ave";
        studentManager.Update(studentToUpdate);
        Console.WriteLine("Student update completed");

        //deleting student
        Console.WriteLine("\n\nDeleting a student from db");
        int studentToDelete = students[12].Id;
        studentManager.Delete(studentToDelete);
        Console.WriteLine("Deletion completed");

        //retrieving a student by id
        Console.WriteLine("\n\nRetrieving a tudent by id from db.....");
        int studentToFetch = students[8].Id;
        Student? retrievedStudent = studentManager.GetById(studentToFetch);
        if (retrievedStudent is not null)
        {
            Console.WriteLine(retrievedStudent);
        }
        else
        {
            Console.WriteLine("Student not found or invalid id");
        }

    }
}