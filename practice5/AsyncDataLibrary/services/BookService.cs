using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public class BookService
{
    private readonly IRepository<Book> _repository;

    public BookService(IRepository<Book> repository) =>
        _repository = repository;

    public async Task<List<Book>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task<Book?> GetByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task AddAsync(Book book) =>
        await _repository.AddAsync(book);

    public async Task UpdateAsync(Book book) =>
        await _repository.UpdateAsync(book);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);

    public async Task<List<Book>> SearchByAuthorAsync(string author)
    {
        var books = await _repository.GetAllAsync();
        return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<Book>> GetInStockAsync()
    {
        var books = await _repository.GetAllAsync();
        return books.Where(b => b.Stock > 0).ToList();
    }

    public List<Book> GetAll() => _repository.GetAll();
    public void Add(Book book) => _repository.Add(book);
}