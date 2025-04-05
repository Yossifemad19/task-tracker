namespace task_cli;

public class ListCommand : ICommand
{
    public void Execute(List<Task> tasks, List<string> parameters)
    {
        if (parameters.Count == 1)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        else if (parameters.Count == 2)
        {
            switch (parameters[1])
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
            }
        }
    }
}