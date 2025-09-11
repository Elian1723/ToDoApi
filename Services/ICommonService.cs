namespace ToDoApi.Services;

public interface ICommonService<TGet, TCreate, TUpdate> where TGet : class where TCreate : class where TUpdate : class
{
    Task<IEnumerable<TGet>> GetAllAsync();
    Task<TGet?> GetByIdAsync(int id);
    Task<TGet> CreateAsync(TCreate entity);
    Task<TGet?> UpdateAsync(TUpdate entity, int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
