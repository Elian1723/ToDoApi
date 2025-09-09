using ToDoApi.Enums;

namespace ToDoApi.Models;

public class ToDo
{
    public int ToDoId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public ToDoPriority Priority { get; set; }
    public ToDoState State { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public DateOnly? DeletedAt { get; set; }
    public DateOnly DueDate { get; set; }
    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}
