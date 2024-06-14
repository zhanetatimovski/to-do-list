namespace ToDoList.Models;

public class Activity
{
    public int Id { get; set; }
    public int ToDoListId { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; }
}
