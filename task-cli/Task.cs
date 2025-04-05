using System.Security.AccessControl;

namespace task_cli;

public class Task
{
    private static int _id = 0;
    public int Id { get; set; }
    public string Description { get; set; }
    public TaskStatus Status  { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static void setIdCounter(int id)
    {
        _id = id;
    }
    public Task(string description)
    {
        Id = ++_id;
        Description = description;
        Status = TaskStatus.todo;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void update(string description)
    {
        Description = description;
    }
    public void updateStatus(TaskStatus status)
    {
        Status = status;
    }


    public override string ToString()
    {
        return $" task {Id}  ," +
               $"description : {Description} ," +
               $"createAt : {CreatedAt} ," +
               $"updatedAt : {UpdatedAt} ," +
               $"status : {Status}";
    }
}