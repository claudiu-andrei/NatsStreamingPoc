using System;
using System.Threading.Tasks;
using NatsStreaming.Interfaces;
using NatsStreaming.Models;
using STAN.Client;

namespace NatsStreaming.Services
{
    public class StreamHandler : IStreamHandler
    {
        private IStanConnection Connection { get; }
        private ICustomSerializer Serializer { get; }

        public StreamHandler(INatsConnectionProvider connectionProvider, 
            ICustomSerializer serializer)
        {
            Connection = connectionProvider.GetStanConnection();
            Serializer = serializer;
        }

        public async Task StreamEventSend<T>(
            EventStreamingModel<T> input,
            string subject) where T: class
        {
              var message = Serializer.Serialize(input);
              await Connection.PublishAsync(
                  subject,
                  System.Text.Encoding.UTF8.GetBytes(message));
        }

        public async Task StreamEventSubscribe<T>(
            StanSubscriptionOptions options,
            string subject,
            string group,
            Func<T, Task> func) where T : class
        {
            Connection.Subscribe(subject, group, options,
                async (obj, args) =>
                {
                    var messageData = System.Text.Encoding.UTF8.GetString(args.Message.Data);
                    var message = Serializer.Deserialize<T>(messageData);
                    await func(message);
                    
                    if (options.ManualAcks)
                        args.Message.Ack();
                });
        }
    }
}
