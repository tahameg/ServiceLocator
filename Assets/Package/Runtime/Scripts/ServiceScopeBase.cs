using System;
using UnityEngine;

namespace TahaCore.ServiceLocator
{
    public abstract class ServiceScopeBase : IServiceScope
    {
        private IServiceLocator locator;

        protected ServiceScopeBase(IServiceLocator locator = null)
        {
            this.locator = locator == null ? new ConcurrentServiceLocator() : locator;
            Configure(this.locator);
        }

        protected abstract void Configure(IServiceLocator locator);

        public bool TryGetService<T>(out T service)
        {
            try
            {
                service = locator.Get<T>();
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get service of type {typeof(T)}: {e.Message}");
                service = default;
                return false;
            }
        }

        public bool TryGetService(Type type, out object service)
        {
            try
            {
                service = locator.Get(type);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to get service of type {type}: {e.Message}");
                service = default;
                return false;
            }
        }
    }
}