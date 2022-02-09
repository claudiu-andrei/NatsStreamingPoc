namespace MPOSAir.Communication.Common.Subscription
{
    public class SubscriptionOptions
    {
        /// <summary>
        /// The durable name for Nats
        /// </summary>
        public string DurableName { get; set; }

        /// <summary>
        /// The group that is receiving the messages
        /// </summary>
        public string Group { get; set; }
    }
}