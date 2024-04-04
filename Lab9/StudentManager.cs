using SQLite;

namespace Lab9;

public class StudentManager
{
    //create an object for connection to db
    private readonly SQLiteConnection _database;

    public StudentManager()
    {
        //instantianting the connection object with the path to the db
        //specified in Constants class
        _database = new SQLiteConnection(Constants.DatabasePath);

        //replace sql query to create a table for student class
        _database.CreateTable<Student>();

        _database.CreateTable<StudentCourse>();
    }

    //add a student
    public void Add(Student student) => _database.Insert(student);

    //delete a student
    public void Delete(int id) => _database.Delete<Student>(id);

    //getting all students in db
    public List<Student> GetAll() => [.. _database.Table<Student>()];

    //getting 1 student by id
    public Student? GetById(int id) => _database.Table<Student>().Where(student => student.Id == id).FirstOrDefault();

    //update a student
    public void Update(Student student) => _database.Update(student);

    public void AddCourseToStudent(Student student, Course course)
    {
        student.Courses.Add(course);
        StudentCourse databaseRecord = new()
        {
            StudentId = student.Id,
            CourseId = course.Id
        };
        _database.Insert(databaseRecord);
    }

    public void GetCoursesByStudentId(int studentId)
    {
        var query = from studentCourse in _database.Table<StudentCourse>()
                    join course in _database.Table<Course>() on studentCourse.CourseId equals course.Id
                    where studentCourse.StudentId == studentId
                    select course;

        List<Course> courses = query.ToList();
        courses.ForEach(Console.WriteLine);
    }
}
