using System;
using UnityEngine;

namespace TahaCore.ServiceLocator
{
    [DefaultExecutionOrder(-9)]
    public abstract class RegistrationScopeBase : MonoBehaviour, IRegistrationScope
    {
        private ServiceLocator serviceLocator;

        protected void Awake()
        {
            serviceLocator = new ServiceLocator();
            Configure(serviceLocator);
        }

        protected abstract void Configure(IServiceLocator serviceLocator);

        public T Get<T>()
        {
            return serviceLocator.Get<T>();
        }
    }

}