using ToDoApi.Enums;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface IToDoRepository : ICommonRepository<ToDo>
{
    Task<ToDo?> GetByTitleAsync(string title);
    Task<IEnumerable<ToDo>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<ToDo>> GetByStateAsync(ToDoState state);
    Task<IEnumerable<ToDo>> GetByPriorityAsync(ToDoPriority priority);
    Task<IEnumerable<ToDo>> GetByDueDateAsync(DateOnly dueDate);
}
