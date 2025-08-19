using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Enums;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ToDoDbContext _context;

    public UserRepository(ToDoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

    public async Task<User> CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        return entity;
    }

    public User Update(User entity)
    {
        _context.Users.Update(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);

        if (user == null) return false;

        user.IsDelete = true;
        user.DeletedAt = DateOnly.FromDateTime(DateTime.UtcNow);

        _context.ToDos.Where(todo => todo.UserId == id).ToList().ForEach(todo => todo.State = ToDoState.Deleted);

        return true;
    }
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<User?> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
}
