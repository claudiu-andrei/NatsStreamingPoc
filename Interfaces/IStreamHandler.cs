using System;
using System.Threading.Tasks;
using NatsStreaming.Models;
using STAN.Client;

namespace NatsStreaming.Interfaces
{
    public interface IStreamHandler
    {
        Task StreamEventSend<T>(
            EventStreamingModel<T> input,
            string subject) where T : class;

        Task StreamEventSubscribe<T>(
            StanSubscriptionOptions options,
            string subject,
            string group,
            Func<T, Task> func) where T : class;
    }
}
