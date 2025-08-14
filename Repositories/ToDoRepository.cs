using System.Threading.Tasks;
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

    public async Task<IEnumerable<ToDo>> GetAll() => await _context.ToDos.ToListAsync();

    public async Task<ToDo?> GetById(int id) => await _context.ToDos.FindAsync(id);

    public async Task Create(ToDo entity) => await _context.ToDos.AddAsync(entity);

    public void Update(ToDo entity) => _context.ToDos.Update(entity);

    public async Task Delete(int id)
    {
        var entity = await GetById(id) ?? throw new KeyNotFoundException($"ToDo with ID {id} not found.");

        entity.State = ToDoState.Deleted;
        entity.DeletedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    }

    public async Task SaveChanges() => await _context.SaveChangesAsync();

    public async Task<ToDo?> GetByTitle(string title) => await _context.ToDos.FirstOrDefaultAsync(t => t.Title == title);

    public async Task<IEnumerable<ToDo>> GetByUserId(int userId) =>
        await _context.ToDos.Where(t => t.UserId == userId).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByCategoryId(int categoryId) => await _context.ToDos.Where(t => t.CategoryId == categoryId).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByState(ToDoState state) => await _context.ToDos.Where(t => t.State == state).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByPriority(ToDoPriority priority) =>
        await _context.ToDos.Where(t => t.Priority == priority).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByDueDate(DateOnly dueDate) =>
        await _context.ToDos.Where(t => t.DueDate == dueDate).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByUserIdAndCategoryId(int userId, int categoryId) =>
        await _context.ToDos.Where(t => t.UserId == userId && t.CategoryId == categoryId).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByUserIdAndState(int userId, ToDoState state) => await _context.ToDos.Where(t => t.UserId == userId && t.State == state).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByUserIdAndPriority(int userId, ToDoPriority priority) =>
        await _context.ToDos.Where(t => t.UserId == userId && t.Priority == priority).ToListAsync();

    public async Task<IEnumerable<ToDo>> GetByUserIdAndDueDate(int userId, DateOnly dueDate) =>
        await _context.ToDos.Where(t => t.UserId == userId && t.DueDate == dueDate).ToListAsync();
}
