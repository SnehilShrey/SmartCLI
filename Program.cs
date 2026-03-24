using System;

class Program
{
    static void Main(string[] args)
    {
        PathHelper.Initialize();

        if (args.Length > 0)
        {
            string input = string.Join(" ", args);
            CommandHandler.Handle(input);  
            return;
        }

        Console.WriteLine("SmartCLI Started! Type 'exit' to quit.");

        while (true)
        {
            Console.Write("> ");

            string? input = Console.ReadLine();

            if (input == null)
                continue;

            input = input.Trim();

            if (input.ToLower() == "exit")
                break;

            if (input.Length == 0)
                continue;

            CommandHandler.Handle(input);
        }
    }
}