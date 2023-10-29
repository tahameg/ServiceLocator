using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TahaCore.ServiceLocator
{
    public static class TypeUtility
    {
        public static List<Type> GetRegistrableTypes<T>(T instance)
        {
            if(instance == null)
                throw new ArgumentNullException(nameof(instance));
            
            Type type = instance.GetType();
            List<Type> inheritedTypes = new List<Type>();
            
            while (type != null)
            {
                inheritedTypes.Add(type);
                type = type.BaseType;
            }

            type = instance.GetType();
            Type[] interfaces = type.GetInterfaces();
            
            foreach (Type interfaceType in interfaces)
            {
                inheritedTypes.Add(interfaceType);
            }

            return inheritedTypes;
        }
        
        public static string TypeToString(Type type)
        {
            return type.FullName;
        }
        
        public static Type StringToType(string typeString)
        {
            return Type.GetType(typeString);
        }
    }
}