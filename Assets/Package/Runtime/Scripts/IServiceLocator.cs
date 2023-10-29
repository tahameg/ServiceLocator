using System;
using System.Collections.Generic;

namespace TahaCore.ServiceLocator
{
    public interface IServiceLocator
    {
        /// <summary>
        /// Register an instance with the given type T.
        /// </summary>
        /// <param name="service">The instance to register.</param>
        /// <typeparam name="T">The type that this instance will be registered with.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown if the given instance is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if there is another instance registered with the same type.
        /// </exception>
        void Register<T>(T service);
        

        /// <summary>
        /// Unregister the service of type T.
        /// </summary>
        /// <typeparam name="T">T is the type of the service to be unregistered</typeparam>
        /// <returns>True if the type is successfully unregistered.</returns>
        public bool Unregister<T>();

        /// <summary>
        /// Get the service of type T.
        /// </summary>
        /// <typeparam name="T">The type of the service to be retrieved.</typeparam>
        /// <returns>The instance that is registered with the given interface type T. </returns>
        /// <exception cref="KeyNotFoundException">Thrown if there is no instance registered with the type T</exception>
        public T Get<T>();

        /// <summary>
        /// Check if the service of type T is registered.
        /// </summary>
        /// <typeparam name="T">The type of the service to be checked.</typeparam>
        /// <returns>True if the service is registered, false otherwise.</returns>
        public bool IsRegistered<T>();

    }
}