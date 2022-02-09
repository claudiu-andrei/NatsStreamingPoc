namespace NatsStreaming.Models
{
    /// <summary>
    /// Model containing the event data as well as extra options for more flexibility (e.g. override destination - where the result is sent)
    /// </summary>
    /// <typeparam name="T">Event content</typeparam>
    public class EventStreamingModel<T> where T: class
    {
        /// <summary>
        /// message content
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// Options for rewriting the destination of the next stream message
        /// </summary>
        public EventStreamingOptions Options { get; set; } = new EventStreamingOptions();
    }
}
