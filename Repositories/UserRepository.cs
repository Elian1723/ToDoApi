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

    public async Task<IEnumerable<User>> GetAll() => await _context.Users.ToListAsync();

    public async Task<User?> GetById(int id) => await _context.Users.FindAsync(id);

    public async Task Create(User entity) => await _context.Users.AddAsync(entity);

    public void Update(User entity) => _context.Users.Update(entity);

    public async Task Delete(int id)
    {
        var user = await GetById(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");

        user.IsDelete = true;
        user.DeletedAt = DateOnly.FromDateTime(DateTime.UtcNow);

        _context.ToDos.Where(todo => todo.UserId == id).ToList().ForEach(todo => todo.State = ToDoState.Deleted);
    }
    public async Task SaveChanges() => await _context.SaveChangesAsync();

    public async Task<User?> GetByEmail(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> UserExists(string email) => await _context.Users.AnyAsync(u => u.Email == email);
}
