using System.Text.Json;

namespace task_cli;

public class AddCommand: ICommand
{
    public void Execute(List<Task> tasks, List<string> parameters)
    {
        if (parameters.Count == 2)
        {
            var task = new Task(parameters[1]);
            tasks.Add(
                task
            );
            File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));
            Console.WriteLine($"# Output: Task added successfully (ID: {task.Id})");
        }
        else
            Console.WriteLine("params for add are invalid");
    }
}