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

    public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

    public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.FindAsync(id);

    public async Task<Category> CreateAsync(Category entity)
    {
        await _context.Categories.AddAsync(entity);
        return entity;
    }

    public Category Update(Category entity)
    {
        _context.Categories.Update(entity);
        
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category {id} not found");
        _context.Categories.Remove(category);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<Category?> GetByNameAsync(string name) => await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

    public async Task<int> GetUsageCountAsync(int categoryId) => await _context.ToDos.CountAsync(t => t.CategoryId == categoryId);
}
