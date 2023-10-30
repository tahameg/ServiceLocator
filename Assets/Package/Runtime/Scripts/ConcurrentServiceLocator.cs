using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TahaCore.ServiceLocator
{
    public class ConcurrentServiceLocator : IServiceLocator
    {
        private readonly ConcurrentDictionary<Type, object> services = new();

        /// <inheritdoc>
        ///     <cref>IServiceLocator.Register(T)</cref>
        /// </inheritdoc>
        public void Register<T>(T service)
        {
            Type type = typeof(T);
            Register(type, service);
        }
        
        /// <inheritdoc>
        ///     <cref>IServiceLocator.Register(Type, object)</cref>
        /// </inheritdoc>
        public void Register(Type type, object service)
        {
            if(service == null)
                throw new ArgumentNullException(nameof(service));
            if (!type.IsAssignableFrom(service.GetType()))
            {
                throw new ArgumentException($"The given service is not assignable from the given type {type}");
            }
            if (!services.TryAdd(type, service))
                throw new ArgumentException($"Service of type {type} is already registered");
        }


        /// <inheritdoc>
        ///     <cref>IServiceLocator.Unregister()</cref>
        /// </inheritdoc>
        public bool Unregister<T>()
        {
            Type type = typeof(T);
            return Unregister(type);
        }

        /// <inheritdoc>
        ///     <cref>IServiceLocator.Unregister(Type)</cref>
        /// </inheritdoc>
        public bool Unregister(Type type)
        {
            if(type == null)
                throw new ArgumentNullException(nameof(type));
            
            return services.TryRemove(type, out _);
        }

        /// <inheritdoc>
        ///     <cref>IServiceLocator.Get()</cref>
        /// </inheritdoc>
        public T Get<T>()
        {
            Type type = typeof(T);
            return (T)Get(type);
        }
        
        /// <inheritdoc>
        ///     <cref>IServiceLocator.Get(Type)</cref>
        /// </inheritdoc>
        public object Get(Type type)
        {
            if(type == null)
                throw new ArgumentNullException(nameof(type));
            
            if (!services.TryGetValue(type, out var value))
                throw new KeyNotFoundException($"Service of type {type} is not registered");
            
            return value;
        }

        /// <inheritdoc>
        ///     <cref>IServiceLocator.IsRegistered()</cref>
        /// </inheritdoc>
        public bool IsRegistered<T>()
        {
            Type type = typeof(T);
            return IsRegistered(type);
        }
        
        /// <inheritdoc>
        ///     <cref>IServiceLocator.IsRegistered()</cref>
        /// </inheritdoc>
        public bool IsRegistered(Type type)
        {
            if(type == null)
                throw new ArgumentNullException(nameof(type));
            
            return services.ContainsKey(type);
        }
    }
}
