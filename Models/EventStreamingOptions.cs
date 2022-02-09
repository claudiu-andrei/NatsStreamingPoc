namespace NatsStreaming.Models
{
    /// <summary>
    /// Extra options for more flexibility when publishing an event on the redis stream
    /// </summary>
    public class EventStreamingOptions
    {
        /// <summary>
        /// Specify the destination where the result of a redis stream processing should arrive
        /// </summary>
        public string OverrideDestinationSuffix { get; set; } = string.Empty;
    }
}
