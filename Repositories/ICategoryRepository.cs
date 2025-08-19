using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface ICategoryRepository : ICommonRepository<Category>
{
    Task<Category?> GetByNameAsync(string name);
    Task<int> GetUsageCountAsync(int categoryId);
    Task<int> GetUsageCountByUserAsync(int categoryId, int userId);
}
