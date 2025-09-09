using ToDoApi.Models.DTOs;

namespace ToDoApi.Services;

public interface IUserService : ICommonService<UserDto, UserCreateDto, UserUpdateDto>
{
    Task<UserDto?> GetByEmailAsync(string email);
    Task<bool> ExistsAsync(string email);
}
