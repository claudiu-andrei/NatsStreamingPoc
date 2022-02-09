using System;
using NATS.Client;
using NatsStreaming.Interfaces;
using STAN.Client;
// ReSharper disable MemberCanBePrivate.Global

namespace NatsStreaming.Services
{
    public class NatsConnectionProvider : INatsConnectionProvider
    {
        public IStanConnection Connection { get; set; }

        private string ConnectionString { get; }

        public NatsConnectionProvider(string connectionString)
        {
            ConnectionString = connectionString;
            CreateConnection();
        }

        public IStanConnection GetStanConnection()
        {
            if (Connection.NATSConnection is { State: ConnState.CONNECTED })
            {
                return Connection;
            }

            CreateConnection();
            return Connection;
        }

        private void CreateConnection()
        {
            var connectionOptions = StanOptions.GetDefaultOptions();
            connectionOptions.NatsURL = ConnectionString;
            connectionOptions.ConnectionLostEventHandler += (sender, args) =>
            {
                Console.WriteLine("Connection Disconnected for Streaming: ");
                Console.WriteLine("   Server: " + ConnectionString);
            };

            Connection = new StanConnectionFactory()
                .CreateConnection(
                    "test-cluster",
                    "basketpub" + Guid.NewGuid(),
                    connectionOptions);

            Console.WriteLine("Created connection for NATS ! ! !");
        }

      
    }
}
