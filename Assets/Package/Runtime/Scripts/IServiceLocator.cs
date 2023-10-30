using System;
using System.Collections.Generic;
using UnityEngine;

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
        /// Register an instance with the given type T.
        /// </summary>
        /// <param name="type">The type that this service will be registered with.</param>
        /// <param name="service">The instance to register.</param>
        /// <exception cref="ArgumentNullException">Thrown if the given instance is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if there is another instance registered with the same type.
        /// Also Thrown if the given type is not assignable from the type of the given instance.
        /// </exception>
        void Register(Type type, object service);

        /// <summary>
        /// Unregister the service of type T.
        /// </summary>
        /// <typeparam name="T">T is the type of the service to be unregistered</typeparam>
        /// <returns>True if the type is successfully unregistered.</returns>
        bool Unregister<T>();
        
        /// <summary>
        /// Unregister the service of type T.
        /// </summary>
        /// <returns>True if the type is successfully unregistered.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if there is no instance registered with the type</exception>
        /// <exception cref="ArgumentNullException">Thrown if there is no instance registered with the type</exception>
        bool Unregister(Type type);
        
        /// <summary>
        /// Get the service of type T.
        /// </summary>
        /// <typeparam name="T">The type of the service to be retrieved.</typeparam>
        /// <returns>The instance that is registered with the given interface type T. </returns>
        /// <exception cref="KeyNotFoundException">Thrown if there is no instance registered with the type T.</exception>
        /// <exception cref="ArgumentNullException">Thrown if there is no instance registered with the type T.</exception>
        T Get<T>();
        
        /// <summary>
        /// Get the service of type.
        /// </summary>
        /// <param name="type">The type of the service to be retrieved.</param>
        /// <returns>The instance that is registered with the given interface type T. </returns>
        /// <exception cref="KeyNotFoundException">Thrown if there is no instance registered with the type</exception>
        /// <exception cref="ArgumentNullException">Thrown if there is no instance registered with the type</exception>
        object Get(Type type);
        
        
        /// <summary>
        /// Check if the service of type T is registered.
        /// </summary>
        /// <typeparam name="T">The type of the service to be checked.</typeparam>
        /// <returns>True if the service is registered, false otherwise.</returns>
        bool IsRegistered<T>();
        
        
        /// <summary>
        /// Check if the service of type T is registered.
        /// </summary>
        /// <param name="type">The type of the service to be checked.</param>
        /// <returns>True if the service is registered, false otherwise.</returns>
        /// <exception cref="ArgumentNullException"> Thrown if given type parameter is null.</exception>
        bool IsRegistered(Type type);

    }
}