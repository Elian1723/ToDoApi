using ToDoApi.Enums;
using ToDoApi.Models.DTOs;

namespace ToDoApi.Services;

public interface IToDoService : ICommonService<ToDoDto, ToDoCreateDto, ToDoUpdateDto>
{
    Task<ToDoDto?> GetByTitleAsync(string title);
    Task<IEnumerable<ToDoDto>> GetByUserIdAsync(int userId);
    Task<IEnumerable<ToDoDto>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<ToDoDto>> GetByStateAsync(ToDoState state);
    Task<IEnumerable<ToDoDto>> GetByPriorityAsync(ToDoPriority priority);
    Task<IEnumerable<ToDoDto>> GetByDueDateAsync(DateOnly dueDate);
    Task<IEnumerable<ToDoDto>> GetByUserIdAndCategoryIdAsync(int userId, int categoryId);
    Task<IEnumerable<ToDoDto>> GetByUserIdAndStateAsync(int userId, ToDoState state);
    Task<IEnumerable<ToDoDto>> GetByUserIdAndPriorityAsync(int userId, ToDoPriority priority);
    Task<IEnumerable<ToDoDto>> GetByUserIdAndDueDateAsync(int userId, DateOnly dueDate);
}
