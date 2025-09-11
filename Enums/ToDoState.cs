using System.Text.Json.Serialization;

namespace ToDoApi.Enums;

public enum ToDoState
{
    [JsonPropertyName("Pending")]
    Pending,
    [JsonPropertyName("InProgress")]
    InProgress,
    [JsonPropertyName("Completed")]
    Completed,
    [JsonPropertyName("Deleted")]
    Deleted
}
