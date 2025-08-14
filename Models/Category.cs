namespace ToDoMinimalApi.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<ToDo> ToDos { get; set; } = [];
}
