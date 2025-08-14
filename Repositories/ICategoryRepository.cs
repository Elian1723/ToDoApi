using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface ICategoryRepository : ICommonRepository<Category>
{
    Task<Category?> GetByName(string name);
    Task<int> GetUsageCount(int categoryId);
    Task<int> GetUsageCountByUser(int categoryId, int userId);
}
