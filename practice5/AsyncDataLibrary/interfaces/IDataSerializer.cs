namespace AsyncDataLibrary.Interfaces;

public interface IDataSerializer
{
    string Serialize<T>(T obj);
    T Deserialize<T>(string data);
}