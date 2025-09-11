using System.Text.Json.Serialization;
using ToDoApi.Enums;

namespace ToDoApi.Models.DTOs;

public class ToDoUpdateDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ToDoPriority Priority { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ToDoState State { get; set; }
    public DateOnly DueDate { get; set; }
    public int CategoryId { get; set; }
}
