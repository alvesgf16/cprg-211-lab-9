using SQLite;

namespace Lab9;

/// <summary>
/// Manages operations related to students in the database.
/// </summary>
public class StudentManager
{
    // Object for connection to the database.
    private readonly SQLiteConnection _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentManager"/> class.
    /// </summary>
    public StudentManager()
    {
        // Instantiating the connection object with the path to the database.
        // Path to the database is specified in Constants class.
        _database = new SQLiteConnection(Constants.DatabasePath);

        // Creates tables for Student and StudentCourse classes in the database.
        _database.CreateTable<Student>();
        _database.CreateTable<StudentCourse>();
    }

    /// <summary>
    /// Adds a student to the database.
    /// </summary>
    /// <param name="student">The student to add.</param>
    public void Add(Student student) => _database.Insert(student);

    /// <summary>
    /// Deletes a student from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the student to delete.</param>
    public void Delete(int id) => _database.Delete<Student>(id);

    /// <summary>
    /// Retrieves all students from the database.
    /// </summary>
    /// <returns>A list of all students in the database.</returns>
    public List<Student> GetAll() => [.. _database.Table<Student>()];

    /// <summary>
    /// Retrieves a student from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the student to retrieve.</param>
    /// <returns>The student with the specified ID, or null if not found.</returns>
    public Student? GetById(int id) => _database.Table<Student>().Where(student => student.Id == id).FirstOrDefault();

    /// <summary>
    /// Updates a student in the database.
    /// </summary>
    /// <param name="student">The student to update.</param>
    public void Update(Student student) => _database.Update(student);

    /// <summary>
    /// Adds a course to a student and updates the database accordingly.
    /// </summary>
    /// <param name="student">The student to add the course to.</param>
    /// <param name="course">The course to add to the student.</param>
    public void AddCourseToStudent(Student student, Course course)
    {
        // Add the course to the student's list of courses.
        student.Courses.Add(course);

        // Create a database record for the student-course relationship and insert it into the database.
        StudentCourse databaseRecord = new()
        {
            StudentId = student.Id,
            CourseId = course.Id
        };
        _database.Insert(databaseRecord);
    }

    /// <summary>
    /// Retrieves courses associated with a student and prints them to the console.
    /// </summary>
    /// <param name="studentId">The ID of the student to retrieve courses for.</param>
    public void GetCoursesByStudentId(int studentId)
    {
        // Query to retrieve courses associated with the specified student ID.
        var query = from studentCourse in _database.Table<StudentCourse>()
                    join course in _database.Table<Course>() on studentCourse.CourseId equals course.Id
                    where studentCourse.StudentId == studentId
                    select course;

        // Execute the query and print the resulting courses to the console.
        List<Course> courses = query.ToList();
        courses.ForEach(Console.WriteLine);
    }
}