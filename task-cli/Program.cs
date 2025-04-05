

using System.Text.Json;
using System.Text.RegularExpressions;

namespace task_cli;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t\t task tracker cli");
        List<Task> tasks;
        if (File.Exists("tasks.json"))
        {
            var file = File.ReadAllText("tasks.json");
            tasks = JsonSerializer.Deserialize<List<Task>>(file);
            
            Task.setIdCounter(tasks.Any()?tasks.Max(t => t.Id):0);
        }
        else
        {
            tasks = new List<Task>();
        }

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("task-cli ");
            Console.ResetColor();
            var cmd = Console.ReadLine();
            if (cmd == "exit")
                break;
            var taskParams = Regex.Matches(cmd, @"[\""].+?[\""]|[^ ]+");
            var Params = taskParams.Select(p=>p.Value.Trim('"')).ToList();

            try
            {
                var command = CommandFactory.GetCommand(Params[0]);
                command.Execute(tasks, Params);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}