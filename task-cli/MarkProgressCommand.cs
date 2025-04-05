using System.Text.Json;

namespace task_cli;

public class MarkProgressCommand:ICommand
{
    public void Execute(List<Task> tasks, List<string> parameters)
    {
        if (parameters.Count == 2)
        {
            var task = tasks.FirstOrDefault(t => t.Id == int.Parse(parameters[1]));
            task.updateStatus(TaskStatus.in_progress);
            File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));

        }
        else
        {
            Console.WriteLine($"params for mark-in-progress are invalid");
        }
    }
}