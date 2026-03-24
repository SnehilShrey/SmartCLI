using System;
using System.IO;

public static class PathHelper
{
    // Store data in user's home directory
    public static readonly string BasePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "SmartCLI");

    public static readonly string DataPath = Path.Combine(BasePath, "Data");

    public static readonly string NotesPath = Path.Combine(DataPath, "notes.txt");
    public static readonly string TasksPath = Path.Combine(DataPath, "tasks.txt");
    public static readonly string HobbiesPath = Path.Combine(DataPath, "hobbies.txt");

    public static void Initialize()
    {
        Directory.CreateDirectory(DataPath);
    }

    public static void ShowPath(string type)
    {
        switch (type.ToLower())
        {
            case "notes":
                Console.WriteLine("Notes file: " + NotesPath);
                break;

            case "tasks":
                Console.WriteLine("Tasks file: " + TasksPath);
                break;

            case "hobbies":
                Console.WriteLine("Hobbies file: " + HobbiesPath);
                break;

            default:
                Console.WriteLine("Invalid path type. Use: notes, tasks, hobbies");
                break;

        }
    }
}