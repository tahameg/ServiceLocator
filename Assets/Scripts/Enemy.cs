using System;
using TahaCore.ServiceLocator.Demo.ExampleServices;
using UnityEngine;

namespace TahaCore.ServiceLocator.Demo
{
    public class Enemy : MonoBehaviour
    {
        public int id;
        
        private IActorInfoLoader loader;
        public ActorInfo Info;

        private void Awake()
        {
            if (ServiceScopeProvider.Instance.Scope.TryGetService(out loader))
            {
                Info = loader.GetActorInfo(id);
                Debug.Log("Enemy is loaded");
                Debug.Log($"Enemy name: {Info.Name}");
                Debug.Log($"Enemy health: {Info.Health}");
                Debug.Log($"Enemy id: {Info.Id}");
            }
        }
        

    }
}