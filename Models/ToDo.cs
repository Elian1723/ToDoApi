using ToDoApi.Enums;

namespace ToDoApi.Models;

public class ToDo
{
    public int ToDoId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public ToDoPriority Priority { get; set; }
    public ToDoState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
