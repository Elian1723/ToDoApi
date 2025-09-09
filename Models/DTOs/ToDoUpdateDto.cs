using ToDoApi.Enums;

namespace ToDoApi.Models.DTOs;

public class ToDoUpdateDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public ToDoPriority Priority { get; set; }
    public ToDoState State { get; set; }
    public DateOnly DueDate { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}
