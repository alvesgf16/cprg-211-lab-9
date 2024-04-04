using SQLite;

namespace Lab9;

/// <summary>
/// Manages operations related to courses in the database.
/// </summary>
public class CourseManager
{
    // Object for connection to the database.
    private readonly SQLiteConnection _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="CourseManager"/> class.
    /// </summary>
    public CourseManager()
    {
        // Instantiating the connection object with the path to the database.
        // Path to the database is specified in Constants class.
        _database = new SQLiteConnection(Constants.DatabasePath);

        // Creates a table for the Course class in the database.
        _database.CreateTable<Course>();
    }

    /// <summary>
    /// Adds a course to the database.
    /// </summary>
    /// <param name="course">The course to add.</param>
    public void Add(Course course) => _database.Insert(course);

    /// <summary>
    /// Deletes a course from the database based on its ID.
    /// </summary>
    /// <param name="courseId">The ID of the course to delete.</param>
    public void Delete(string courseId) => _database.Delete<Course>(courseId);

    /// <summary>
    /// Retrieves all courses from the database.
    /// </summary>
    /// <returns>A list of all courses in the database.</returns>
    public List<Course> GetAll() => [.. _database.Table<Course>()];

    /// <summary>
    /// Retrieves a course from the database based on its ID.
    /// </summary>
    /// <param name="courseId">The ID of the course to retrieve.</param>
    /// <returns>The course with the specified ID, or null if not found.</returns>
    public Course? GetById(string courseId) => _database.Table<Course>().Where(course => course.Id == courseId).FirstOrDefault();

    /// <summary>
    /// Updates a course in the database.
    /// </summary>
    /// <param name="course">The updated course.</param>
    public void Update(Course course) => _database.Update(course);
}