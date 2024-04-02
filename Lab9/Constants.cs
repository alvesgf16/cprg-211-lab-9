namespace Lab9;

public class Constants
{
    public const string DATABASE_FILENAME = "Student.db3";

    public static string DatabasePath => Path.Combine(
        Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName,
        DATABASE_FILENAME
    );
}
