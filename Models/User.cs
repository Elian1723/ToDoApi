namespace ToDoMinimalApi.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsDelete { get; set; }
    public DateTime? DeletedAt { get; set; }
    public virtual ICollection<ToDo> ToDos { get; set; } = [];
}
