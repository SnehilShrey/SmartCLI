using System;
using System.IO;
using System.Linq;

public static class HobbyManager
{
    private static string path = PathHelper.HobbiesPath;

    // ➕ Add hobby
    public static void Add(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Hobby cannot be empty.");
            return;
        }

        File.AppendAllText(path, "[ ] " + text + Environment.NewLine);
        Console.WriteLine("Hobby added!");
    }

    // 📖 List hobbies
    public static void List()
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        var hobbies = File.ReadAllLines(path);

        if (hobbies.Length == 0)
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        for (int i = 0; i < hobbies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {hobbies[i]}");
        }
    }

    // ✏️ Edit hobby
    public static void Edit(string argument)
    {
        var parts = argument.Split(' ', 2);

        if (parts.Length < 2)
        {
            Console.WriteLine("Usage: edit-hobby <line> <text>");
            return;
        }

        if (!int.TryParse(parts[0], out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        var hobbies = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > hobbies.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        // Preserve status
        string status = hobbies[index - 1].StartsWith("[x]") ? "[x] " : "[ ] ";

        hobbies[index - 1] = status + parts[1];

        File.WriteAllLines(path, hobbies);

        Console.WriteLine("Hobby updated!");
    }

    // ❌ Delete hobby
    public static void Delete(string argument)
    {
        if (!int.TryParse(argument, out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        var hobbies = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > hobbies.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        hobbies.RemoveAt(index - 1);

        File.WriteAllLines(path, hobbies);

        Console.WriteLine("Hobby deleted!");
    }

    // ✅ Mark as done
    public static void Done(string argument)
    {
        if (!int.TryParse(argument, out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        var hobbies = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > hobbies.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (hobbies[index - 1].StartsWith("[x]"))
        {
            Console.WriteLine("Hobby already completed.");
            return;
        }

        hobbies[index - 1] = "[x]" + hobbies[index - 1].Substring(3);

        File.WriteAllLines(path, hobbies);

        Console.WriteLine("Hobby marked as done!");
    }

    // 🔄 Undo hobby
    public static void Undo(string argument)
    {
        if (!int.TryParse(argument, out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No hobbies found.");
            return;
        }

        var hobbies = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > hobbies.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (hobbies[index - 1].StartsWith("[ ]"))
        {
            Console.WriteLine("Hobby already pending.");
            return;
        }

        hobbies[index - 1] = "[ ]" + hobbies[index - 1].Substring(3);

        File.WriteAllLines(path, hobbies);

        Console.WriteLine("Hobby marked as pending!");
    }
}