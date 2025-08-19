using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface IUserRepository : ICommonRepository<User>
{
    Task<User?> GetByEmail(string email);
}
