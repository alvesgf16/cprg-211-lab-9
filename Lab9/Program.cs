using Lab9;

using SQLite;

internal class Program
{
    private static void Main(string[] args)
    {
        // Resetting the database by dropping existing tables
        SQLiteConnection database = new(Constants.DatabasePath);
        database.DropTable<Student>();
        database.DropTable<Course>();
        database.DropTable<StudentCourse>();

        // Recreating tables and instantiating managers
        StudentManager studentManager = new();
        CourseManager courseManager = new();

        // Initializing the database with a set of initial students
        List<Student> initialStudents =
        [
            new Student()
            {
                    Name = "Jane",
                    Email = "Jane@sait.ca",
                    Address = "999 Main Str. Calgary"
            },
            new Student()
            {
                    Name = "John Doe",
                    Email = "john@example.com",
                    Address = "123 Main St"
            },
            new Student()
            {
                    Name = "Jane Smith",
                    Email = "jane@example.com",
                    Address = "456 Elm St"
            },
            new Student()
            {
                    Name = "Michael Johnson",
                    Email = "michael@example.com",
                    Address = "789 Oak St"
            },
            new Student()
            {
                    Name = "Emily Davis",
                    Email = "emily@example.com",
                    Address = "101 Pine St"
            },
            new Student()
            {
                    Name = "Christopher Wilson",
                    Email = "chris@example.com",
                    Address = "202 Maple St"
            },
            new Student()
            {
                    Name = "Jessica Brown",
                    Email = "jessica.brown@sait.ca",
                    Address = "123 SAIT Avenue"
            },
            new Student()
            {
                    Name = "Matthew Martinez",
                    Email = "matthew@example.com",
                    Address = "404 Walnut St"
            },
            new Student()
            {
                    Name = "Amanda Taylor",
                    Email = "amanda@example.com",
                    Address = "505 Birch St"
            },
            new Student()
            {
                    Name = "David Anderson",
                    Email = "david@example.com",
                    Address = "606 Spruce St"
            },
        ];
        initialStudents.ForEach(studentManager.Add);

        // Retrieving and printing all students from the database
        List<Student> students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        // Adding a new student to the database
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

        // Updating a student's information
        Console.WriteLine("\n\nUpdating new Student...");
        Student studentToUpdate = students[9];
        studentToUpdate.Email = "updatedemail@sait.ca";
        studentToUpdate.Address = "updatedAddress 32nd Ave";
        studentManager.Update(studentToUpdate);
        Console.WriteLine("Student update completed");

        students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        // Deleting a student from the database
        Console.WriteLine("\n\nDeleting a student from db");
        int studentToDelete = students[10].Id;
        studentManager.Delete(studentToDelete);
        Console.WriteLine("Deletion completed");

        students = studentManager.GetAll();
        Console.WriteLine("Printing Students");
        students.ForEach(Console.WriteLine);

        // Retrieving a student by ID
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

        // Adding courses to the database
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

        // Retrieving and printing all courses from the database
        List<Course> courses = courseManager.GetAll();
        Console.WriteLine("\nPrinting Courses");
        courses.ForEach(Console.WriteLine);

        // Adding courses to a student
        Console.WriteLine("\nAdding courses to a student...");
        Student studentToAddCourses = students[0];
        Course firstCourse = courseManager.GetById("1001");
        Course secondCourse = courseManager.GetById("1002");
        studentManager.AddCourseToStudent(studentToAddCourses, firstCourse);
        studentManager.AddCourseToStudent(studentToAddCourses, secondCourse);
        Console.WriteLine("Courses added to the student");

        // Retrieving courses associated with a student
        Console.WriteLine("\nRetrieving courses associated with a student...");
        Console.WriteLine($"Courses associated with student {studentToAddCourses.Id} ({studentToAddCourses.Name}):");
        studentManager.GetCoursesByStudentId(studentToAddCourses.Id);
    }
}