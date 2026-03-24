using System;

public static class CommandHandler
{
    public static void Handle(string input)
    {
        // Split only first word (command)
        var parts = input.Split(' ', 2);

        string command = parts[0].ToLower();
        string argument = parts.Length > 1 ? parts[1] : "";

        switch (command)
        {
            // 📒 NOTES
            case "note":
                NotesManager.Add(argument);
                break;

            case "list-note":
                NotesManager.List();
                break;

            case "edit-note":
                NotesManager.Edit(argument);
                break;

            case "delete-note":
                NotesManager.Delete(argument);
                break;

            // ✅ TASKS
            case "task":
                TaskManager.Add(argument);
                break;

            case "list-task":
                TaskManager.List();
                break;

            case "edit-task":
                TaskManager.Edit(argument);
                break;

            case "delete-task":
                TaskManager.Delete(argument);
                break;

            case "done-task":
                TaskManager.Done(argument);
                break;

            case "undo-task":
                TaskManager.Undo(argument);
                break;

            // 🎯 HOBBIES
            case "hobby":
                HobbyManager.Add(argument);
                break;

            case "list-hobby":
                HobbyManager.List();
                break;

            case "edit-hobby":
                HobbyManager.Edit(argument);
                break;

            case "delete-hobby":
                HobbyManager.Delete(argument);
                break;

            case "done-hobby":
                HobbyManager.Done(argument);
                break;

            case "undo-hobby":
                HobbyManager.Undo(argument);
                break;

            // 🔍 SEARCH
            case "search":
                SearchManager.Search(argument);
                break;

            // 📂 PATH
            case "path":
                PathHelper.ShowPath(argument);
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}