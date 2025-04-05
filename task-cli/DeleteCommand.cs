using System.Text.Json;

namespace task_cli;

public class DeleteCommand:ICommand
{
    public void Execute(List<Task> tasks, List<string> parameters)
    {
        if (parameters.Count == 2)
        {
            tasks.Remove(tasks.FirstOrDefault(t=>t.Id == int.Parse(parameters[1])));
            File.WriteAllText("tasks.json", JsonSerializer.Serialize(tasks));

        }
        else
        {
            Console.WriteLine($"params for delete are invalid");
        }
    }
}