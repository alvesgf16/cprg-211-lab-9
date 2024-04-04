using Lab9;

internal class Program
{
    private static void Main(string[] args)
    {
        StudentManager studentManager = new();
        CourseManager courseManager = new();

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

        students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        //updating a student
        Console.WriteLine("\n\nUpdating new Student...");
        Student studentToUpdate = students[9];
        studentToUpdate.Email = "updatedemail@sait.ca";
        studentToUpdate.Address = "updatedAddress 32nd Ave";
        studentManager.Update(studentToUpdate);
        Console.WriteLine("Student update completed");

        students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        //deleting student
        Console.WriteLine("\n\nDeleting a student from db");
        int studentToDelete = students[10].Id;
        studentManager.Delete(studentToDelete);
        Console.WriteLine("Deletion completed");

        students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        //retrieving a student by id
        Console.WriteLine("\n\nRetrieving a student by id from db.....");
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

        //adding courses
        Console.WriteLine("\nAdding courses...");
        List<Course> coursesToBeAdded = [
            new Course()
            {
                Id = "1001",
                Name = "Fundamentals of Web Development",
                Credits = 3,
            },
            new Course()
            {
                Id = "1002",
                Name = "Introduction to Full Stack Programming",
                Credits = 3,
            },
            new Course()
            {
                Id = "1003",
                Name = "Databases",
                Credits = 3,
            },
            new Course()
            {
                Id = "1004",
                Name = "Principles of Software Analysis and Design",
                Credits = 4,
            },
            new Course()
            {
                Id = "1005",
                Name = "Object-Oriented Programming",
                Credits = 4,
            }
        ];
        coursesToBeAdded.ForEach((course) =>
        {
            courseManager.Add(course);
            Console.WriteLine($"Course {course.Name} added");
        });

        List<Course> courses = courseManager.GetAll();
        Console.WriteLine("Printing Courses");
        courses.ForEach(Console.WriteLine);
    }
}