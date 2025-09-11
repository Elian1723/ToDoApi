using System.Text.Json.Serialization;

namespace ToDoApi.Enums;

public enum ToDoPriority
{
    [JsonPropertyName("Low")]
    Low,
    [JsonPropertyName("Medium")]
    Medium,
    [JsonPropertyName("High")]
    High
}
