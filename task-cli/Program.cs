

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
            Task.setIdCounter(tasks.Max(t => t.Id));
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
            switch (Params[0])
            {
                case "add":
                    if (Params.Count == 2)
                    {
                        var task = new Task(Params[1]);
                        tasks.Add(
                            task
                        );
                        File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));
                        Console.WriteLine($"# Output: Task added successfully (ID: {task.Id})");
                    }
                    else
                        Console.WriteLine("params for add are invalid");
                    break;
                case "list":
                    if (Params.Count == 1)
                    {
                        foreach (var task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                    }
                    else if (Params.Count == 2)
                    {
                        switch (Params[1])
                        {
                            case "done":
                                foreach (var task in tasks.Where(t => t.Status == TaskStatus.done))
                                {
                                    Console.WriteLine(task);
                                }
                                break;
                            case "in-progress":
                                foreach (var task in tasks.Where(t => t.Status == TaskStatus.in_progress))
                                {
                                    Console.WriteLine(task);
                                }
                                break;
                            case "todo":
                                foreach (var task in tasks.Where(t => t.Status == TaskStatus.todo))
                                {
                                    Console.WriteLine(task);
                                }
                                break;
                            default:
                                Console.WriteLine($"\t# Unknown task: {Params[1]}");
                                break;
                        }
                    }
                    else
                        Console.WriteLine($"params for list are invalid");
                    break;
                case "update":
                    if (Params.Count == 3)
                    {
                        var task = tasks.FirstOrDefault(t=>t.Id == int.Parse(Params[1]));
                        if (task != null)
                        {
                            task.update(Params[2]);
                            File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));
                        }
                        else
                        {
                            Console.WriteLine($"# Task not found: {Params[1]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"params for update are invalid");
                    }
                    break;
                case "delete":
                    if (Params.Count == 2)
                    {
                        tasks.Remove(tasks.FirstOrDefault(t=>t.Id == int.Parse(Params[1])));
                        File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));

                    }
                    else
                    {
                        Console.WriteLine($"params for delete are invalid");
                    }
                    break;
                case "mark-in-progress":
                    if (Params.Count == 2)
                    {
                        var task = tasks.FirstOrDefault(t => t.Id == int.Parse(Params[1]));
                        task.updateStatus(TaskStatus.in_progress);
                        File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));

                    }
                    else
                    {
                        Console.WriteLine($"params for mark-in-progress are invalid");
                    }
                    break;
                case "mark-done":
                    if (Params.Count == 2)
                    {
                        var task = tasks.FirstOrDefault(t => t.Id == int.Parse(Params[1]));
                        task.updateStatus(TaskStatus.done);
                        File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));

                    }
                    break;
                default:
                    Console.WriteLine($"{taskParams[0]} is not a task tracker command");
                    break;
            }
            // Console.WriteLine(tasks.Count);
            // Console.WriteLine(cmd.ToLower().Split(" ")[0]);

        }
    }
}