using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace PolarionPlug.Api
{
    class SessionBehavior : IEndpointBehavior
    {
        void IEndpointBehavior.AddBindingParameters(
            ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        void IEndpointBehavior.ApplyClientBehavior(
            ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(mSessionInspector);
        }

        void IEndpointBehavior.ApplyDispatchBehavior(
            ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        void IEndpointBehavior.Validate(ServiceEndpoint endpoint)
        {
        }

        IClientMessageInspector mSessionInspector = new SessionInspector();
    }
}
