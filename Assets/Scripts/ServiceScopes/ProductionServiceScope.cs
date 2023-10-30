using TahaCore.ServiceLocator.Demo.ExampleServices;

namespace TahaCore.ServiceLocator.Demo.ServiceScopes
{
    public class ProductionServiceScope : ServiceScopeBase
    {
        protected override void Configure(IServiceLocator locator)
        {
            locator.Register<IActorInfoLoader>(
                new ActorInfoLoaderFromWeb("https://www.mockactorservice.com/api/actorinfo/"));
        }
    }
}