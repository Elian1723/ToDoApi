using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Enums;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly ToDoDbContext _context;

    public ToDoRepository(ToDoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDo>> GetAllAsync() => await _context.ToDos.ToListAsync();

    public async Task<ToDo?> GetByIdAsync(int id) => await _context.ToDos.FindAsync(id);

    public async Task<ToDo> CreateAsync(ToDo entity)
    {
        await _context.ToDos.AddAsync(entity);
        return entity;
    }

    public ToDo Update(ToDo entity)
    {
        _context.ToDos.Update(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"ToDo {id} not found");

        entity.State = ToDoState.Deleted;
        entity.DeletedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<ToDo?> GetByTitleAsync(string title) => await _context.ToDos.FirstOrDefaultAsync(t => t.Title == title);

    public async Task<IEnumerable<ToDo>> GetByCategoryIdAsync(int categoryId) => await _context.ToDos.Where(t => t.CategoryId == categoryId).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByStateAsync(ToDoState state) => await _context.ToDos.Where(t => t.State == state).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByPriorityAsync(ToDoPriority priority) =>
        await _context.ToDos.Where(t => t.Priority == priority).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByDueDateAsync(DateOnly dueDate) =>
        await _context.ToDos.Where(t => t.DueDate == dueDate).ToListAsync();
}
