using SQLite;

namespace Lab9;

public class CourseManager
{
    //create an object for connection to db
    private readonly SQLiteConnection _database;

    public CourseManager()
    {
        //instantiating the connection object witht he path to the db
        //path to db is specifed in Constants class
        _database = new SQLiteConnection(Constants.DatabasePath);

        //replaces sql query to create a table for student class
        _database.CreateTable<Course>();
    }

    //add a course
    public void Add(Course course) => _database.Insert(course);

    //delete a course
    public void Delete(string courseId) => _database.Delete<Course>(courseId);

    //getting all courses in db
    public List<Course> GetAll() => _database.Table<Course>().ToList();

    //getting 1 course by id
    public Course? GetById(string courseId) => _database.Table<Course>().Where(course => course.Id == courseId).FirstOrDefault();

    //update a course
    public void Update(Course course) => _database.Update(course);
}
