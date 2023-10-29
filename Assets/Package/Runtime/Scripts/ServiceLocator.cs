using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TahaCore.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly ConcurrentDictionary<Type, object> services = new();

        /// <inheritdoc>
        ///     <cref>IServiceLocator.Register</cref>
        /// </inheritdoc>
        public void Register<T>(T service)
        {
            Type type = typeof(T);
            if (!services.TryAdd(typeof(T), service))
                throw new ArgumentException($"Service of type {type} is already registered");
        }
        
        
        /// <inheritdoc>
        ///     <cref>IServiceLocator.Unregister</cref>
        /// </inheritdoc>
        public bool Unregister<T>()
        {
             return services.TryRemove(typeof(T), out _);
        }

        /// <inheritdoc>
        ///     <cref>IServiceLocator.Register</cref>
        /// </inheritdoc>
        public T Get<T>()
        {
            Type type = typeof(T);

            if (!services.TryGetValue(type, out var value))
                throw new KeyNotFoundException($"Service of type {type} is not registered");
            
            return (T)value;
        }
        
        /// <inheritdoc>
        ///     <cref>IServiceLocator.IsRegistered</cref>
        /// </inheritdoc>
        public bool IsRegistered<T>()
        {
            Type type = typeof(T);
            return services.ContainsKey(type);
        }
    }
}
