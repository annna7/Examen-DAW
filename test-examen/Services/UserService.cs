using Microsoft.EntityFrameworkCore;
using test_examen.Models;
using test_examen.Models.Dto;

namespace test_examen.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new Exception("User not found!");
        }

        return user;
    }

    public async Task<User> UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        var user = await GetUser(userId);
        user.Name = updateUserDto.Name ?? user.Name;
        user.Email = updateUserDto.Email ?? user.Email;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUser(Guid id)
    {
        var user = await GetUser(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> CreateUser(CreateUserDto createUserDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = createUserDto.Name,
            Email = createUserDto.Email
        };
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}