using System;
using System.IO;

public static class SearchManager
{
    public static void Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Please provide a search keyword.");
            return;
        }

        keyword = keyword.ToLower();

        bool found = false;

        // 🔍 Search Notes
        if (File.Exists(PathHelper.NotesPath))
        {
            var notes = File.ReadAllLines(PathHelper.NotesPath);

            foreach (var note in notes)
            {
                if (note.ToLower().Contains(keyword))
                {
                    Console.WriteLine("Note: " + note);
                    found = true;
                }
            }
        }

        // 🔍 Search Tasks
        if (File.Exists(PathHelper.TasksPath))
        {
            var tasks = File.ReadAllLines(PathHelper.TasksPath);

            foreach (var task in tasks)
            {
                if (task.ToLower().Contains(keyword))
                {
                    Console.WriteLine("Task: " + task);
                    found = true;
                }
            }
        }

        // 🔍 Search Hobbies
        if (File.Exists(PathHelper.HobbiesPath))
        {
            var hobbies = File.ReadAllLines(PathHelper.HobbiesPath);

            foreach (var hobby in hobbies)
            {
                if (hobby.ToLower().Contains(keyword))
                {
                    Console.WriteLine("Hobby: " + hobby);
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No matches found.");
        }
    }
}