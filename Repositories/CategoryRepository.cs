using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ToDoDbContext _context;

    public CategoryRepository(ToDoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAll() => await _context.Categories.ToListAsync();

    public async Task<Category?> GetById(int id) => await _context.Categories.FindAsync(id);

    public async Task Create(Category entity) => await _context.Categories.AddAsync(entity);

    public void Update(Category entity) => _context.Categories.Update(entity);

    public async Task Delete(int id)
    {
        var category = await GetById(id) ?? throw new KeyNotFoundException($"Category with ID {id} not found.");

        _context.Categories.Remove(category);
    }

    public async Task SaveChanges() => await _context.SaveChangesAsync();

    public async Task<Category?> GetByName(string name) => await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

    public async Task<int> GetUsageCount(int categoryId) => await _context.ToDos.CountAsync(t => t.CategoryId == categoryId);

    public async Task<int> GetUsageCountByUser(int categoryId, int userId) =>
        await _context.ToDos.CountAsync(t => t.CategoryId == categoryId && t.UserId == userId);
}
