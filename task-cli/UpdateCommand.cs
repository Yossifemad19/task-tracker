using System.Text.Json;

namespace task_cli;

public class UpdateCommand:ICommand
{
    public void Execute(List<Task> tasks, List<string> parameters)
    {
        if (parameters.Count == 3)
        {
            var task = tasks.FirstOrDefault(t=>t.Id == int.Parse(parameters[1]));
            if (task != null)
            {
                task.update(parameters[2]);
                File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));
            }
            else
            {
                Console.WriteLine($"# Task not found: {parameters[1]}");
            }
        }
        else
        {
            Console.WriteLine($"params for update are invalid");
        }
    }
}