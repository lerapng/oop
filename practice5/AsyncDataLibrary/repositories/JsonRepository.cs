using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Infrastructure;
using System.Reflection;

namespace AsyncDataLibrary.Repositories;

public class JsonRepository<T> : IRepository<T> where T : class
{
    private readonly FileStorageProvider _storage;
    private readonly IDataSerializer _serializer;
    private readonly string _fileName;

    public JsonRepository(FileStorageProvider storage, IDataSerializer serializer)
    {
        _storage = storage;
        _serializer = serializer;
        _fileName = $"{typeof(T).Name.ToLower()}s.json";
    }

    public async Task<List<T>> GetAllAsync()
    {
        string json = await _storage.ReadAsync(_fileName);
        return _serializer.Deserialize<List<T>>(json);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var list = await GetAllAsync();
        return list.FirstOrDefault(x => GetId(x) == id);
    }

    public async Task AddAsync(T entity)
    {
        var list = await GetAllAsync();
        SetId(entity, list.Count > 0 ? list.Max(x => GetId(x)) + 1 : 1);
        list.Add(entity);
        await _storage.WriteAsync(_fileName, _serializer.Serialize(list));
    }

    public async Task UpdateAsync(T entity)
    {
        var list = await GetAllAsync();
        int index = list.FindIndex(x => GetId(x) == GetId(entity));
        if (index >= 0) list[index] = entity;
        await _storage.WriteAsync(_fileName, _serializer.Serialize(list));
    }

    public async Task DeleteAsync(int id)
    {
        var list = await GetAllAsync();
        list.RemoveAll(x => GetId(x) == id);
        await _storage.WriteAsync(_fileName, _serializer.Serialize(list));
    }

    public List<T> GetAll()
    {
        string json = _storage.Read(_fileName);
        return _serializer.Deserialize<List<T>>(json);
    }

    public T? GetById(int id) =>
        GetAll().FirstOrDefault(x => GetId(x) == id);

    public void Add(T entity)
    {
        var list = GetAll();
        SetId(entity, list.Count > 0 ? list.Max(x => GetId(x)) + 1 : 1);
        list.Add(entity);
        _storage.Write(_fileName, _serializer.Serialize(list));
    }

    public void Update(T entity)
    {
        var list = GetAll();
        int index = list.FindIndex(x => GetId(x) == GetId(entity));
        if (index >= 0) list[index] = entity;
        _storage.Write(_fileName, _serializer.Serialize(list));
    }

    public void Delete(int id)
    {
        var list = GetAll();
        list.RemoveAll(x => GetId(x) == id);
        _storage.Write(_fileName, _serializer.Serialize(list));
    }

    private static int GetId(T entity)
    {
        PropertyInfo? prop = typeof(T).GetProperty("Id");
        return prop != null ? (int)prop.GetValue(entity)! : 0;
    }

    private static void SetId(T entity, int id)
    {
        PropertyInfo? prop = typeof(T).GetProperty("Id");
        prop?.SetValue(entity, id);
    }
}