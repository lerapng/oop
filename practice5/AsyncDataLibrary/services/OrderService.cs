using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class OrderService
{
    private readonly IRepository<Order> _repository;

    public OrderService(IRepository<Order> repository) =>
        _repository = repository;

    public async Task<List<Order>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task<Order?> GetByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task AddAsync(Order order) =>
        await _repository.AddAsync(order);

    public async Task UpdateStatusAsync(int orderId, OrderStatus newStatus)
    {
        Order? order = await _repository.GetByIdAsync(orderId);
        if (order == null) throw new InvalidOperationException($"Замовлення #{orderId} не знайдено.");
        order.Status = newStatus;
        await _repository.UpdateAsync(order);
    }

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);

    public async Task<List<Order>> GetByUserIdAsync(int userId)
    {
        var orders = await _repository.GetAllAsync();
        return orders.Where(o => o.UserId == userId).ToList();
    }

    public async Task<List<Order>> GetByStatusAsync(OrderStatus status)
    {
        var orders = await _repository.GetAllAsync();
        return orders.Where(o => o.Status == status).ToList();
    }

    public List<Order> GetAll() => _repository.GetAll();
    public void Add(Order order) => _repository.Add(order);
}