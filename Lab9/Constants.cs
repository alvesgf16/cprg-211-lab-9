namespace Lab9;

/// <summary>
/// Provides constants used throughout the application.
/// </summary>
public class Constants
{
    /// <summary>
    /// The filename of the SQLite database used for storing student data.
    /// </summary>
    public const string DATABASE_FILENAME = "Student.db3";

    /// <summary>
    ///The full path to the SQLite database file.
    /// </summary>
    public static string DatabasePath => Path.Combine(
        Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName,
        DATABASE_FILENAME
    );
}