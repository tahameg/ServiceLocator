using TahaCore.ServiceLocator.Demo.ExampleServices;

namespace TahaCore.ServiceLocator.Demo.ServiceScopes
{
    public class MockServiceScope : ServiceScopeBase
    {
        protected override void Configure(IServiceLocator locator)
        {
            locator.Register<IActorInfoLoader>(new MockActorInfoLoader());
        }
    }
}