namespace ToDoApi.Repositories;

public interface ICommonRepository<T>
{
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task SaveChangesAsync();
    T Update(T entity);
}
