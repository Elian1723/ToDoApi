using ToDoApi.Enums;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface IToDoRepository : ICommonRepository<ToDo>
{
    Task<ToDo?> GetByTitle(string title);
    Task<IEnumerable<ToDo>> GetByUserId(int userId);
    Task<IEnumerable<ToDo>> GetByCategoryId(int categoryId);
    Task<IEnumerable<ToDo>> GetByState(ToDoState state);
    Task<IEnumerable<ToDo>> GetByPriority(ToDoPriority priority);
    Task<IEnumerable<ToDo>> GetByDueDate(DateOnly dueDate);
    Task<IEnumerable<ToDo>> GetByUserIdAndCategoryId(int userId, int categoryId);
    Task<IEnumerable<ToDo>> GetByUserIdAndState(int userId, ToDoState state);
    Task<IEnumerable<ToDo>> GetByUserIdAndPriority(int userId, ToDoPriority priority);
    Task<IEnumerable<ToDo>> GetByUserIdAndDueDate(int userId, DateOnly dueDate);
}
