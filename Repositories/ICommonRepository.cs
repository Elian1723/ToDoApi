namespace ToDoApi.Repositories;

public interface ICommonRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}
