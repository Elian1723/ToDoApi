using ToDoApi.Models.DTOs;

namespace ToDoApi.Services;

public interface ICategoryService : ICommonService<CategoryDto, CategoryCreateDto, CategoryUpdateDto>
{
    Task<CategoryDto?> GetByNameAsync(string name);
    Task<int> GetUsageCountAsync(int categoryId);
    Task<int> GetUsageCountByUserAsync(int categoryId, int userId);
    Task<bool> ExistsAsync(string name);
}
