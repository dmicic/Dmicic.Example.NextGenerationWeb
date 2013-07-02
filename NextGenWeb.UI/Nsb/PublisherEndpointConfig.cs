using NServiceBus;

namespace NextGenWeb.UI.Nsb
{
    [EndpointName("NextGenWeb")]
	public class PublisherEndpointConfig : IConfigureThisEndpoint, AsA_Publisher
    { }
}