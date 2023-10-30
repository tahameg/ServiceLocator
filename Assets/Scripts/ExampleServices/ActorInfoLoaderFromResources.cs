using UnityEngine;

namespace TahaCore.ServiceLocator.Demo.ExampleServices
{
    public class ActorInfoLoaderFromResources : IActorInfoLoader
    {
        private readonly string resourcePath;
        public ActorInfoLoaderFromResources(string resourcePath)
        {
            this.resourcePath = resourcePath;
        }

        public ActorInfo GetActorInfo(int id)
        {
            Debug.Log($"Actor with id {id} is loaded from resource at {resourcePath}");
            return new ActorInfo(id, "ActorFromResource", 100);
        }
    }
}