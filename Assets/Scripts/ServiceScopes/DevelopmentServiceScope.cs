using TahaCore.ServiceLocator.Demo.ExampleServices;

namespace TahaCore.ServiceLocator.Demo.ServiceScopes
{
    public class DevelopmentServiceScope : ServiceScopeBase
    {
        protected override void Configure(IServiceLocator locator)
        {
            locator.Register<IActorInfoLoader>(new ActorInfoLoaderFromResources("ActorInfo"));
        }
    }
}