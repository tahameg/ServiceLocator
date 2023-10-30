using System;
using TahaCore.ServiceLocator.Demo.ExampleServices;
using UnityEngine;

namespace TahaCore.ServiceLocator.Demo
{
    public class Enemy : MonoBehaviour
    {
        public int id;
        
        private IActorInfoLoader loader;
        private void Awake()
        {
            if (ServiceScopeProvider.Scope.TryGetService(out loader))
            {
                var info = loader.GetActorInfo(id);
                Debug.Log("Enemy is loaded");
                Debug.Log($"Enemy name: {info.Name}");
                Debug.Log($"Enemy health: {info.Health}");
                Debug.Log($"Enemy id: {info.Id}");
            }
        }
        

    }
}