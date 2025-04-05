namespace task_cli;

public static class CommandFactory
{
    public static ICommand GetCommand(string command)
    {
        return command switch
        {
            "add" => new AddCommand(),
            "delete" => new DeleteCommand(),
            "update" => new UpdateCommand(),
            "list" => new ListCommand(),
            "mark-done" => new MarkDoneCommand(),
            "mark-in-progress" => new MarkProgressCommand(),
            _ => throw new InvalidOperationException($"Unknown command {command}")
        };
    }
}