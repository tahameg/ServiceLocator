using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TahaCore.ServiceLocator
{
    [Serializable]
    public class ObjectRegistrationInfo
    {
        [SerializeField] private Object instance;
        
        [SerializeField]
        [HideInInspector]
        private string selectedTypeName ;
        
        public Object Instance => instance;
        public Type SelectedType => selectedTypeName == null ? null :
            TypeUtility.StringToType(selectedTypeName);
    }
}