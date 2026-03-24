using System;
using System.IO;
using System.Linq;

public static class TaskManager
{
    private static string path = PathHelper.TasksPath;

    // ➕ Add task
    public static void Add(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Task cannot be empty.");
            return;
        }

        File.AppendAllText(path, "[ ] " + text + Environment.NewLine);
        Console.WriteLine("Task added!");
    }

    // 📖 List tasks
    public static void List()
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        var tasks = File.ReadAllLines(path);

        if (tasks.Length == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        for (int i = 0; i < tasks.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    // ✏️ Edit task
    public static void Edit(string argument)
    {
        var parts = argument.Split(' ', 2);

        if (parts.Length < 2)
        {
            Console.WriteLine("Usage: edit-task <line> <text>");
            return;
        }

        if (!int.TryParse(parts[0], out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        var tasks = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > tasks.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        // Preserve status ([ ] or [x])
        string status = tasks[index - 1].StartsWith("[x]") ? "[x] " : "[ ] ";

        tasks[index - 1] = status + parts[1];

        File.WriteAllLines(path, tasks);

        Console.WriteLine("Task updated!");
    }

    // ❌ Delete task
    public static void Delete(string argument)
    {
        if (!int.TryParse(argument, out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        var tasks = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > tasks.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        tasks.RemoveAt(index - 1);

        File.WriteAllLines(path, tasks);

        Console.WriteLine("Task deleted!");
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
            Console.WriteLine("No tasks found.");
            return;
        }

        var tasks = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > tasks.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (tasks[index - 1].StartsWith("[x]"))
        {
            Console.WriteLine("Task already completed.");
            return;
        }

        tasks[index - 1] = "[x]" + tasks[index - 1].Substring(3);

        File.WriteAllLines(path, tasks);

        Console.WriteLine("Task marked as done!");
    }

    // 🔄 Undo (mark as pending)
    public static void Undo(string argument)
    {
        if (!int.TryParse(argument, out int index))
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        var tasks = File.ReadAllLines(path).ToList();

        if (index <= 0 || index > tasks.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        if (tasks[index - 1].StartsWith("[ ]"))
        {
            Console.WriteLine("Task already pending.");
            return;
        }

        tasks[index - 1] = "[ ]" + tasks[index - 1].Substring(3);

        File.WriteAllLines(path, tasks);

        Console.WriteLine("Task marked as pending!");
    }
}