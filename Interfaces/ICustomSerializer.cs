namespace NatsStreaming.Interfaces
{
    public interface ICustomSerializer
    {
        string Serialize<T>(T input) where T : class;

        T Deserialize<T>(string input) where T : class;
    }
}
