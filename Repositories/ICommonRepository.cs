namespace ToDoApi.Repositories;

public interface ICommonRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task Create(T entity);
    void Update(T entity);
    Task Delete(int id);
    Task SaveChanges();
}
