using test_examen.Models;
using test_examen.Models.Dto;

namespace test_examen.Services;

public interface IUserService
{
    public Task<IEnumerable<User>> GetAllUsers();
    public Task<User> GetUser(Guid id);
    public Task<User> UpdateUser(Guid userId, UpdateUserDto updateUserDto);
    public Task DeleteUser(Guid id);
    public Task<User> CreateUser(CreateUserDto createUserDto);
}