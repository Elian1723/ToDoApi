using AutoMapper;
using ToDoApi.Models;
using ToDoApi.Models.DTOs;
using ToDoApi.Repositories;

namespace ToDoApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateAsync(UserCreateDto entity)
    {
        var user = _mapper.Map<User>(entity);

        await _userRepository.CreateAsync(user);
        await _userRepository.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task DeleteAsync(int id)
    {
        if (_userRepository.GetByIdAsync(id).Result is null)
        {
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        await _userRepository.DeleteAsync(id);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        return user is null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user is null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task UpdateAsync(UserUpdateDto entity, int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        _mapper.Map(entity, user);
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string email) => (await _userRepository.GetByEmailAsync(email)) is not null;
}
