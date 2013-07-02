using NServiceBus;

namespace NextGenWeb.Server.Nsb
{
    [EndpointName("NextGenWeb")]
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With().DefaultBuilder().JsonSerializer();

            Configure.With()
                .DefaultBuilder()
                .JsonSerializer()
                .MsmqTransport()
                .MsmqSubscriptionStorage()
                    .IsTransactional(true)
                    .PurgeOnStartup(true)
                .UnicastBus()
                    .ImpersonateSender(false)
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
        }
    }
}