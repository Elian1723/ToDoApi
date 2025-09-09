namespace ToDoApi.Models.DTOs;

public class UserDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int TodoCount { get; set; }
    public int TodoCompletedCount { get; set; }
    public int TodoInProgressCount { get; set; }
    public int TodoPendingCount { get; set; }
}