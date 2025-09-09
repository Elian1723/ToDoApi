using AutoMapper;
using ToDoApi.Models.DTOs;
using ToDoApi.Enums;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _todoRepository;
    private readonly IMapper _mapper;

    public ToDoService(IToDoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<ToDoDto> CreateAsync(ToDoCreateDto entity)
    {
        var toDo = _mapper.Map<ToDo>(entity);

        await _todoRepository.CreateAsync(toDo);
        await _todoRepository.SaveChangesAsync();

        return _mapper.Map<ToDoDto>(toDo);
    }

    public async Task DeleteAsync(int id)
    {
        if (_todoRepository.GetByIdAsync(id).Result is null)
        {
            throw new KeyNotFoundException($"ToDo with ID {id} not found.");
        }

        await _todoRepository.DeleteAsync(id);
        await _todoRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ToDoDto>> GetAllAsync()
    {
        var toDos = await _todoRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByCategoryIdAsync(int categoryId)
    {
        var toDos = await _todoRepository.GetByCategoryIdAsync(categoryId);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByDueDateAsync(DateOnly dueDate)
    {
        var toDos = await _todoRepository.GetByDueDateAsync(dueDate);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<ToDoDto?> GetByIdAsync(int id)
    {
        var toDo = await _todoRepository.GetByIdAsync(id);

        return toDo is null ? null : _mapper.Map<ToDoDto>(toDo);
    }

    public async Task<IEnumerable<ToDoDto>> GetByPriorityAsync(ToDoPriority priority)
    {
        var toDos = await _todoRepository.GetByPriorityAsync(priority);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByStateAsync(ToDoState state)
    {
        var toDos = await _todoRepository.GetByStateAsync(state);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<ToDoDto?> GetByTitleAsync(string title)
    {
        var toDo = await _todoRepository.GetByTitleAsync(title);

        return toDo is null ? null : _mapper.Map<ToDoDto?>(toDo);
    }

    public async Task<IEnumerable<ToDoDto>> GetByUserIdAndCategoryIdAsync(int userId, int categoryId)
    {
        var toDos = await _todoRepository.GetByUserIdAndCategoryIdAsync(userId, categoryId);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByUserIdAndDueDateAsync(int userId, DateOnly dueDate)
    {
        var toDos = await _todoRepository.GetByUserIdAndDueDateAsync(userId, dueDate);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByUserIdAndPriorityAsync(int userId, ToDoPriority priority)
    {
        var toDos = await _todoRepository.GetByUserIdAndPriorityAsync(userId, priority);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByUserIdAndStateAsync(int userId, ToDoState state)
    {
        var toDos = await _todoRepository.GetByUserIdAndStateAsync(userId, state);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task<IEnumerable<ToDoDto>> GetByUserIdAsync(int userId)
    {
        var toDos = await _todoRepository.GetByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<ToDoDto>>(toDos ?? []);
    }

    public async Task UpdateAsync(ToDoUpdateDto entity, int id)
    {
        if (_todoRepository.GetByIdAsync(id).Result is null)
        {
            throw new KeyNotFoundException($"ToDo with ID {id} not found.");
        }

        var toDo = _mapper.Map<ToDo>(entity);

        _todoRepository.Update(toDo);
        await _todoRepository.SaveChangesAsync();
    }
}
