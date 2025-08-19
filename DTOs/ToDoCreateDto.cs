using ToDoApi.Enums;

namespace ToDoApi.DTOs;

public class ToDoCreateDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public ToDoPriority Priority { get; set; }
    public DateOnly DueDate { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}
