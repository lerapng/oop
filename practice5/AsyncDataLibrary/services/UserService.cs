using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class UserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository) =>
        _repository = repository;

    public async Task<List<User>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task AddAsync(User user) =>
        await _repository.AddAsync(user);

    public async Task UpdateAsync(User user) =>
        await _repository.UpdateAsync(user);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);

    public async Task<User?> FindByEmailAsync(string email)
    {
        var users = await _repository.GetAllAsync();
        return users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public List<User> GetAll() => _repository.GetAll();
    public void Add(User user) => _repository.Add(user);
}