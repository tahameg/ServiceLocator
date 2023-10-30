using UnityEngine;

namespace TahaCore.ServiceLocator.Demo.ExampleServices
{
    public class ActorInfoLoaderFromWeb : IActorInfoLoader
    {
        private readonly string url;
        
        public ActorInfoLoaderFromWeb(string url)
        {
            this.url = url;
        }

        public ActorInfo GetActorInfo(int id)
        {
            Debug.Log($"Actor with id {id} is loaded from web at {url}");
            return new ActorInfo(id, "ActorFromWeb", 100);
        }
    }
}
        