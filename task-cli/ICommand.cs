namespace task_cli;

public interface ICommand
{
    public void Execute(List<Task> tasks,List<string> parameters);
}