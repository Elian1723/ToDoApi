using ToDoApi.Enums;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface IToDoRepository : ICommonRepository<ToDo>
{
    Task<ToDo?> GetByTitleAsync(string title);
    Task<IEnumerable<ToDo>> GetByUserIdAsync(int userId);
    Task<IEnumerable<ToDo>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<ToDo>> GetByStateAsync(ToDoState state);
    Task<IEnumerable<ToDo>> GetByPriorityAsync(ToDoPriority priority);
    Task<IEnumerable<ToDo>> GetByDueDateAsync(DateOnly dueDate);
    Task<IEnumerable<ToDo>> GetByUserIdAndCategoryIdAsync(int userId, int categoryId);
    Task<IEnumerable<ToDo>> GetByUserIdAndStateAsync(int userId, ToDoState state);
    Task<IEnumerable<ToDo>> GetByUserIdAndPriorityAsync(int userId, ToDoPriority priority);
    Task<IEnumerable<ToDo>> GetByUserIdAndDueDateAsync(int userId, DateOnly dueDate);
}
