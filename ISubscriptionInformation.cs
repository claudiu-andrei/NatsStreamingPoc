using MPOSAir.Communication.Common.Subscription;

namespace NatsStreaming
{
    public interface ISubscriptionInformation
    {
        string NatsUrl { get; }

        string ClientId { get; }

        SubscriptionOptions SubscriptionOptions { get; }
    }
}
