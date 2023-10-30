using UnityEngine;

namespace TahaCore.ServiceLocator.Demo.ExampleServices
{
    public class MockActorInfoLoader : IActorInfoLoader
    {
        public ActorInfo GetActorInfo(int id)
        {
            Debug.Log("MockActorInfoLoader is called");
            return new ActorInfo(id, "ActorFromMock", 100);
        }
    }
}