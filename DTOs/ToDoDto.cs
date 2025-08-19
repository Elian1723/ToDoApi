using System.Text.Json.Serialization;
using ToDoApi.Enums;

namespace ToDoApi.DTOs;

public class ToDoDto
{
    public int ToDoId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ToDoPriority Priority { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ToDoState State { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
    public DateOnly DueDate { get; set; }
    public int UserId { get; set; }
    public int? CategoryId { get; set; }
    public string UserName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
}
