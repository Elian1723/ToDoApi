using ToDoApi.Enums;
using ToDoApi.Models.DTOs;

namespace ToDoApi.Services;

public interface IToDoService : ICommonService<ToDoDto, ToDoCreateDto, ToDoUpdateDto>
{
    Task<ToDoDto?> GetByTitleAsync(string title);
    Task<IEnumerable<ToDoDto>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<ToDoDto>> GetByStateAsync(ToDoState state);
    Task<IEnumerable<ToDoDto>> GetByPriorityAsync(ToDoPriority priority);
    Task<IEnumerable<ToDoDto>> GetByDueDateAsync(DateOnly dueDate);
}
