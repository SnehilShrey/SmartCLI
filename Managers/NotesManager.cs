using System;
using System.IO;
using System.Linq;

public static class NotesManager
{
    private static string path = PathHelper.NotesPath;

    // ➕ Add note
    public static void Add(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Note cannot be empty.");
            return;
        }

        File.AppendAllText(path, text + Environment.NewLine);
        Console.WriteLine("Note added!");
    }

    // 📖 List notes
    public static void List()
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("No notes found.");
            return;
        }

        var notes = File.ReadAllLines(path);

        if (notes.Length == 0)
        {
            Console.WriteLine("No notes found.");
            return;
        }

        for (int i = 0; i < notes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {notes[i]}");
        }
    }

    // ✏️ Edit note
    public static void Edit(string argument)
    {
        var parts = argument.Split(' ', 2);

        if (parts.Length < 2)
        {
            Console.WriteLine("Usage: edit-note <line> <text>");
            return;
        }

        if (!int.TryParse(parts[0], out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No notes found.");
            return;
        }

        var notes = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > notes.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        notes[index - 1] = parts[1];

        File.WriteAllLines(path, notes);

        Console.WriteLine("Note updated!");
    }

    // ❌ Delete note
    public static void Delete(string argument)
    {
        if (!int.TryParse(argument, out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No notes found.");
            return;
        }

        var notes = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > notes.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        notes.RemoveAt(index - 1);

        File.WriteAllLines(path, notes);

        Console.WriteLine("Note deleted!");
    }
}