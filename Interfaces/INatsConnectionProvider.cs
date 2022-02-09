using STAN.Client;

namespace NatsStreaming.Interfaces
{
    public interface INatsConnectionProvider
    {
        IStanConnection Connection { get; }

        IStanConnection GetStanConnection();
    }
}
